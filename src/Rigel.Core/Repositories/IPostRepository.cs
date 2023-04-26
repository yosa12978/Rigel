using Rigel.Core.Models;

namespace Rigel.Core.Repositories
{
    public interface IPostRepository : IBaseRepository<Post, string>
    {
        Task<List<Post>> FindCategoryPosts(string categoryId);
        Task<List<Post>> FindUserPosts(string userId);
    }
}