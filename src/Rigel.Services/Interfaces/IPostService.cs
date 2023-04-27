namespace Rigel.Services.Interfaces
{
    public interface IPostService
    {
        Task<List<Post>> FindAll();
        Task<Post?> FindById(string postId);
    }
}