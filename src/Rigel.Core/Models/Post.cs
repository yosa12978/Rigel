namespace Rigel.Core.Models
{
    public class Post : BaseModel<string>
    {
        public string? subject { get; set; } = default!;
        public string categoryId { get; set; } = default!;
        public Category category { get; set; } = default!;
        public string authorId { get; set; } = default!;
        public User author { get; set; } = default!;
        public List<Message> messages { get; set; } = default!;
        public DateTime pubDate { get; set; } = DateTime.UtcNow;
        public DateTime changeDate { get; set; } = DateTime.UtcNow;
    }
}