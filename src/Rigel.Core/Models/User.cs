namespace Rigel.Core 
{
    public class User : BaseModel<string>
    {
        public string username { get; set; } = default!;
        public string password { get; set; } = default!;
        public string salt { get; set; } = default!;
        public List<Post> posts { get; set; } = default!;
        public DateTime regDate { get; set; } = DateTime.Now;
    }
}