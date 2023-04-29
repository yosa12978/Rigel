using Rigel.Services.Interfaces;

namespace Rigel.Services.Impl
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repo;
        private readonly IIdGenerator _idgen;
        public PostService(IPostRepository repo, IIdGenerator idgen)
        {
            _repo = repo;
            _idgen = idgen;
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
            return PostDto.MapToDto(post);
        }

        public async Task<PostDto> DeletePost(string postId, string userId)
        {
            Post? post = await _repo.FindById(postId);
            if (post == null || post.authorId != userId)
                throw new NotFoundException("post not found");
            return PostDto.MapToDto(await _repo.Delete(post));
        }

        public async Task<List<PostDto>> FindAll()
        {
            List<Post> posts = await _repo.FindAll();
            return await Task.Run(() => posts.Select(x => PostDto.MapToDto(x)).ToList());
        }

        public async Task<PostDto> FindById(string postId)
        {
            Post? post = await _repo.FindById(postId);
            if (post == null)
                throw new NotFoundException("post not found");
            return PostDto.MapToDto(post);
        }

        public async Task<List<PostDto>> FindPostsByCategory(string categoryId)
        {
            IEnumerable<Post> posts = await _repo.FindCategoryPosts(categoryId);
            return await Task.Run(() => posts.Select(x => PostDto.MapToDto(x)).ToList());
        }

        public async Task<PostDto> UpdatePost(UpdatePostDto dto, string postId, string userId)
        {
            Post? post = await _repo.FindById(postId);
            if (post == null || post.authorId != userId)
                throw new NotFoundException("post not found");
            post.subject = dto.subject ?? post.subject;
            return PostDto.MapToDto(await _repo.Update(post));
        }
    }
}