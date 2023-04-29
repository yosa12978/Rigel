using Rigel.Services.Interfaces;

namespace Rigel.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IIdGenerator _idgen;
        public UserService(IUserRepository userRepository, IIdGenerator idgen)
        {
            _userRepository = userRepository;
            _idgen = idgen;
        }
        public Task<UserDto> CreateUser(CreateUserDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> DeleteUser(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> FindById(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> FindByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> FindUser(string username, string password)
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

        public Task<UserDto> UpdateUser(UpdateUserDto dto, string userId)
        {
            throw new NotImplementedException();
        }
    }
}