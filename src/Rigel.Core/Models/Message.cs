namespace Rigel.Core.Models
{
    public class Message : BaseModel<string>
    {
        public string content { get; set; } = null!;
        public DateTime pubDate { get; set; } = DateTime.Now;
        public string? parentId { get; set; } = null!;
        public Message? parent { get; set; } = null!; 
        public List<Message> replies { get; set; } = null!;
        public string authorId { get; set; } = default!;
        public User author { get; set; } = default!;
        public string postId { get; set; } = default!;
        public Post post { get; set; } = default!;
        public bool Edited { get; set; } = false;
        public bool Deleted { get; set; } = false;
    }
}