using Rigel.Services.Interfaces;

namespace Rigel.Services.Impl
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repo;
        public PostService(IPostRepository repo)
        {
            _repo = repo;
        }
        public async Task<PostDto?> CreatePost(CreatePostDto dto, string userId)
        {
            Post post = new Post
            {
                id = Guid.NewGuid().ToString().Replace("-", ""),
                subject = dto.subject,
                categoryId = dto.categoryId,
                authorId = userId,
            };
            await _repo.Create(post);
            return PostDto.MapToDto(post);
        }

        public async Task<PostDto?> DeletePost(string postId, string userId)
        {
            Post? post = await _repo.FindById(postId);
            if (post == null || post.authorId != userId)
                throw new NotFoundException("post not found");
            return PostDto.MapToDto(await _repo.Delete(post));
        }

        public async Task<List<PostDto>> FindAll()
        {
            return (await _repo.FindAll()).Select(x => PostDto.MapToDto(x)!).ToList();
        }

        public async Task<PostDto?> FindById(string postId)
        {
            return PostDto.MapToDto((await _repo.FindById(postId))!);
        }

        public async Task<List<PostDto>> FindPostsByCategory(string categoryId)
        {
            return (await _repo.FindCategoryPosts(categoryId)).Select(x => PostDto.MapToDto(x)!).ToList();
        }

        public async Task<PostDto?> UpdatePost(UpdatePostDto dto, string postId, string userId)
        {
            Post? post = await _repo.FindById(postId);
            if (post == null || post.authorId != userId)
                throw new NotFoundException("post not found");
            post.subject = dto.subject ?? post.subject;
            return PostDto.MapToDto((await _repo.Update(post)));
        }
    }
}