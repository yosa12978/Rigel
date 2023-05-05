using Microsoft.Extensions.Logging;
using Rigel.Services.Interfaces;

namespace Rigel.Services.Impl
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repo;
        private readonly IIdGenerator _idgen;
        private readonly ILogger<PostService> _logger;
        public PostService(IPostRepository repo, IIdGenerator idgen, ILogger<PostService> logger)
        {
            _repo = repo;
            _idgen = idgen;
            _logger = logger;
        }
        public async Task<PostDto> CreatePost(CreatePostDto dto, string userId)
        {
            Post post = new Post
            {
                id = _idgen.NewId(),
                subject = dto.subject,
                categoryId = dto.categoryId,
                authorId = userId,
            };
            await _repo.Create(post);
            _logger.LogInformation($"creating post with id = {post.id}");
            return PostDto.MapToDto(post);
        }

        public async Task<PostDto> DeletePost(string postId, string userId)
        {
            Post? post = await _repo.FindById(postId);
            if (post == null || post.authorId != userId)
                throw new NotFoundException("post not found");
            _logger.LogInformation($"deleting post with id = {post.id}");
            return PostDto.MapToDto(await _repo.Delete(post));
        }

        public async Task<PaginatedList<PostDto>> FindAll(int page = 1)
        {
            List<Post> posts = await _repo.FindAll();
            _logger.LogInformation("returning posts");
            return await Task.Run(() => new PaginatedList<PostDto>(posts.Select(x => PostDto.MapToDto(x)), page)); // todo this is slow
        }

        public async Task<PostDto> FindById(string postId)
        {
            Post? post = await _repo.FindById(postId);
            if (post == null)
                throw new NotFoundException("post not found");
            _logger.LogInformation($"returning post with id = {post.id}");
            return PostDto.MapToDto(post);
        }

        public async Task<PaginatedList<PostDto>> FindPostsByCategory(string categoryId, int page = 1)
        {
            IEnumerable<Post> posts = await _repo.FindCategoryPosts(categoryId);
            _logger.LogInformation($"returning posts with categoryId = {categoryId}");
            return await Task.Run(() => new PaginatedList<PostDto>(posts.Select(x => PostDto.MapToDto(x)), page)); // todo this is slow
        }

        public async Task<PostDto> UpdatePost(UpdatePostDto dto, string postId, string userId)
        {
            Post? post = await _repo.FindById(postId);
            if (post == null || post.authorId != userId)
                throw new NotFoundException("post not found");
            post.subject = dto.subject ?? post.subject;
            post.edited = true;
            _logger.LogInformation($"updating post with id = {post.id}");
            return PostDto.MapToDto(await _repo.Update(post));
        }
    }
}