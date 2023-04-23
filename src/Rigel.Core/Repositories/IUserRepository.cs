namespace Rigel.Core
{
    public interface IUserRepository : IBaseRepository<User, string>
    {
        Task<bool> IsUserExist(string username, string passwordHash);
        Task<bool> IsUsernameTaken(string username);
    }
}