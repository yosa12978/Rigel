namespace Rigel.Core 
{
    public class Post : BaseModel<string>
    {
        public string? content { get; set; } = null!;
        public DateTime pubDate { get; set; } = DateTime.Now;
        public string? parentId { get; set; } = null!;
        public Post? parent { get; set; } = null!; 
        public string authorId { get; set; } = default!;
        public User author { get; set; } = default!;
        public string threadId { get; set; } = default!;
        public Thread thread { get; set; } = default!;
    }
}