namespace Rigel.Services.Interfaces
{
    public interface IPostService
    {
        Task<PageDto<PostDto>> FindAll(int page = 1);
        Task<PostDto> FindById(string postId);
        Task<PageDto<PostDto>> FindPostsByCategory(string categoryId, int page = 1);
        Task<PostDto> CreatePost(CreatePostDto dto, string userId);
        Task<PostDto> UpdatePost(UpdatePostDto dto, string postId, string userId);
        Task<PostDto> DeletePost(string postId, string userId);
    }
}