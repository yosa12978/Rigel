namespace Rigel.Dtos.Response
{
    public class PostDto 
    {
        public string id { get; set; } = default!;
        public string subject { get; set; } = default!;
        public string categoryId { get; set; } = default!;
        public CategoryDto category { get; set; } = default!;
        public string authorId { get; set; } = default!;
        public UserDto author { get; set; } = default!;
        public DateTime pubDate { get; set; } = default!;
        public DateTime changeDate { get; set; } = default!;

        public static Post MapToObj(PostDto dto) 
        {
            return new Post
            {
                id = dto.id,
                subject = dto.subject,
                pubDate = dto.pubDate,
                categoryId = dto.categoryId,
                category = CategoryDto.MapToObj(dto.category),
                authorId = dto.authorId,
                author = UserDto.MapToObj(dto.author),
                changeDate = dto.changeDate,
            };
        }

        public static PostDto MapToDto(Post obj)
        {
            return new PostDto
            {
                id = obj.id,
                subject = obj.subject,
                pubDate = obj.pubDate,
                categoryId = obj.categoryId,
                category = CategoryDto.MapToDto(obj.category),
                authorId = obj.authorId,
                author = UserDto.MapToDto(obj.author),
                changeDate = obj.changeDate,
            };
        }
    }
}