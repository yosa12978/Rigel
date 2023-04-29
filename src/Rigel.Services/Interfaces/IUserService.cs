namespace Rigel.Services.Interfaces
{
    public interface IUserService
    {
        Task<User?> CreateUser(CreateUserDto dto);
        Task<User?> DeleteUser(string userId);
        Task<User?> UpdateUser(UpdateUserDto dto, string userId);
        Task<User?> FindById(string userId);
        Task<User?> FindByUsername(string username);
        Task<User?> FindUser(string username, string password);
        Task<bool> IsUserExist(string username, string password);
        Task<bool> IsUsernameTaken(string username);
    }
}