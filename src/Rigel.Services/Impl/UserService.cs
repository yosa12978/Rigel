using Rigel.Services.Interfaces;

namespace Rigel.Services.Impl
{
    public class UserService : IUserService
    {
        public Task<User?> CreateUser(CreateUserDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<User?> DeleteUser(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<User?> FindById(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<User?> FindByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task<User?> FindUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUserExist(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUsernameTaken(string username)
        {
            throw new NotImplementedException();
        }

        public Task<User?> UpdateUser(UpdateUserDto dto, string userId)
        {
            throw new NotImplementedException();
        }
    }
}