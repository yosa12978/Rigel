namespace Rigel.Core.Models
{
    public class User : BaseModel<string>
    {
        public string username { get; set; } = default!;
        public string nickname { get; set; } = default!;
        public string avatar { get; set; } = default!;
        public string password { get; set; } = default!;
        public string salt { get; set; } = default!;
        public List<Post> posts { get; set; } = default!;
        public List<Message> messages { get; set; } = default!;
        public string role { get; set; } = Role.ROLE_USER;
        public DateTime regDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}