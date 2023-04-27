namespace Rigel.Dtos
{
    public class UserDto 
    {
        public string id { get; set; } = default!;
        public string username { get; set; } = default!;
        public string nickname { get; set; } = default!;
        public string avatar { get; set; } = default!;
        public DateTime regDate { get; set; } = default!;
        public bool IsValid() 
        {
            return true;
        }
    }
}