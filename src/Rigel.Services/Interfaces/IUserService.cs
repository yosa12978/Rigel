namespace Rigel.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateUser(CreateUserDto dto);
        Task<UserDto> DeleteUser(string userId);
        Task<UserDto> UpdateUser(UpdateUserDto dto, string userId);
        Task<UserDto> FindById(string userId);
        Task<UserDto> FindByUsername(string username);
        Task<UserDto> FindUser(string username, string password);
        Task<bool> IsUserExist(string username, string password);
        Task<bool> IsUsernameTaken(string username);
    }
}