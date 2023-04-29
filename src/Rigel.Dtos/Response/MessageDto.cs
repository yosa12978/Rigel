namespace Rigel.Dtos.Response
{
    public class MessageDto 
    {
        public string id { get; set; } = default!;
        public string content { get; set; } = null!;
        public DateTime pubDate { get; set; } = default!;
        public string? parentId { get; set; } = null!;
        public MessageDto? parent { get; set; } = null!; 
        // public List<MessageDto> replies { get; set; } = null!;
        public string authorId { get; set; } = default!;
        public UserDto author { get; set; } = default!;
        public string postId { get; set; } = default!;
        public PostDto post { get; set; } = default!;
        
        public static Message? MapToObj(MessageDto? dto) 
        {
            if (dto == null)
                return null;
            return new Message
            {
                id = dto.id,
                content = dto.content,
                pubDate = dto.pubDate,
                parentId = dto.parentId,
                parent = MapToObj(dto.parent!),
                authorId = dto.authorId,
                author = UserDto.MapToObj(dto.author),
                postId = dto.postId,
                post = PostDto.MapToObj(dto.post)!,
            };
        }

        public static MessageDto? MapToDto(Message? obj)
        {
            if (obj == null)
                return null;
            return new MessageDto
            {
                id = obj.id,
                content = obj.content,
                pubDate = obj.pubDate,
                parentId = obj.parentId,
                parent = MapToDto(obj.parent!),
                authorId = obj.authorId,
                author = UserDto.MapToDto(obj.author),
                postId = obj.postId,
                post = PostDto.MapToDto(obj.post),
            };
        }
    }
}