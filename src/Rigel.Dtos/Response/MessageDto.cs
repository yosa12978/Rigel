namespace Rigel.Dtos.Response
{
    public class MessageDto 
    {
        public string id { get; set; } = default!;
        public string? content { get; set; } = null!;
        public DateTime pubDate { get; set; } = default!;
        public string? parentId { get; set; } = null!;
        public MessageDto? parent { get; set; } = null!; 
        public List<MessageDto> replies { get; set; } = null!;
        public string authorId { get; set; } = default!;
        public UserDto author { get; set; } = default!;
        public string postId { get; set; } = default!;
        public PostDto post { get; set; } = default!;
        public bool IsValid() 
        {
            return true;
        }
    }
}