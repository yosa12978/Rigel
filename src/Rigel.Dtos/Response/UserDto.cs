namespace Rigel.Dtos.Response
{
    public class UserDto 
    {
        public string id { get; set; } = default!;
        public string username { get; set; } = default!;
        public string nickname { get; set; } = default!;
        public string avatar { get; set; } = default!;
        public DateTime regDate { get; set; } = default!;
        
        public static User? MapToObj(UserDto? dto) 
        {
            if (dto == null)
                return null;
            return new User
            {
                id = dto.id,
                username = dto.username,
                nickname = dto.nickname,
                avatar = dto.avatar,
                regDate = dto.regDate,
            };
        }

        public static UserDto? MapToDto(User? obj)
        {
            if (obj == null)
                return null;
            return new UserDto
            {
                id = obj.id,
                username = obj.username,
                nickname = obj.nickname,
                avatar = obj.avatar,
                regDate = obj.regDate,
            };
        }
    }
}