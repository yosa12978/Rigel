namespace Rigel.Services.Interfaces
{
    public interface IPostService
    {
        Task<List<PostDto>> FindAll();
        Task<PostDto> FindById(string postId);
        Task<List<PostDto>> FindPostsByCategory(string categoryId);
        Task<PostDto> CreatePost(CreatePostDto dto, string userId);
        Task<PostDto> UpdatePost(UpdatePostDto dto, string postId, string userId);
        Task<PostDto> DeletePost(string postId, string userId);
    }
}