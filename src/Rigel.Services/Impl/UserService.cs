using System.Xml;
using Rigel.Services.Interfaces;

namespace Rigel.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IIdGenerator _idgen;
        private readonly IPasswordHelper _ph;
        public UserService(IUserRepository userRepository, IIdGenerator idgen, IPasswordHelper ph)
        {
            _userRepository = userRepository;
            _idgen = idgen;
            _ph = ph;
        }
        public async Task<UserDto> CreateUser(CreateUserDto dto)
        {
            if (dto.password != dto.password_confirm) 
                throw new BadRequestException("passwords doesnt match");
            string salt = await Task.Run(() => _ph.NewSalt(16));
            User user = new User
            {
                username = dto.username,
                nickname = dto.username,
                salt = salt,
                password = _ph.Hash(dto.password+salt),
                avatar = $"https://api.dicebear.com/5.x/identicon/svg?seed={dto.username}&backgroundColor=ffffff", // todo: change this do some default icons;
            };
            await _userRepository.Create(user);
            return UserDto.MapToDto(user);
        }

        public async Task<UserDto> DeleteUser(string userId)
        {
            User? user = await _userRepository.FindById(userId);
            if (user == null)
                throw new NotFoundException("user not found");
            await _userRepository.Delete(user);
            return UserDto.MapToDto(user);
        }

        public async Task<UserDto> DisableUser(string userId)
        {
            User? user = await _userRepository.FindById(userId);
            if (user == null) // todo do smth with userid
                throw new NotFoundException("user not found");
            user.isActive = false;
            return UserDto.MapToDto(await _userRepository.Update(user));
        }

        public async Task<UserDto> EnableUser(string userId)
        {
            User? user = await _userRepository.FindById(userId);
            if (user == null) // todo do smth with userid
                throw new NotFoundException("user not found");
            user.isActive = true;
            return UserDto.MapToDto(await _userRepository.Update(user));
        }

        public async Task<UserDto> FindById(string userId)
        {
            User? user = await _userRepository.FindById(userId);
            if (user == null)
                throw new NotFoundException("user not found");
            return UserDto.MapToDto(user);
        }

        public async Task<UserDto> FindByUsername(string username)
        {
            User? user = await _userRepository.FindByUsername(username);
            if (user == null)
                throw new NotFoundException("user not found");
            return UserDto.MapToDto(user);
        }

        public async Task<UserDto> FindUser(string username, string password)
        {
            User? user = await _userRepository.FindByUsername(username);
            if (user == null || user.password != _ph.Hash(password+user.salt))
                throw new NotFoundException("user not found");
            return UserDto.MapToDto(user);
        }

        public async Task<UserDto> UpdateUser(UpdateUserDto dto, string userId)
        {
            User? user = await _userRepository.FindById(userId);
            if (user == null) // todo do smth with userid
                throw new NotFoundException("user not found");
            user.nickname = dto.nickname ?? user.nickname;
            user.avatar = dto.avatar ?? user.avatar;
            return UserDto.MapToDto(await _userRepository.Update(user));
        }
    }
}