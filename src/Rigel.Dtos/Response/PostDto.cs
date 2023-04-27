namespace Rigel.Dtos.Response
{
    public class PostDto 
    {
        public string id { get; set; } = default!;
        public string? subject { get; set; } = default!;
        public string categoryId { get; set; } = default!;
        public CategoryDto category { get; set; } = default!;
        public string authorId { get; set; } = default!;
        public UserDto author { get; set; } = default!;
        public DateTime pubDate { get; set; } = default!;
        public DateTime changeDate { get; set; } = default!;
        public bool IsValid() 
        {
            return true;
        }
    }
}