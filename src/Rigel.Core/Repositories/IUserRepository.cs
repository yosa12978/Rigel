using Rigel.Core.Models;

namespace Rigel.Core.Repositories
{
    public interface IUserRepository : IBaseRepository<User, string>
    {
        Task<bool> IsUserExist(string username, string passwordHash);
        Task<bool> IsUsernameTaken(string username);
    }
}