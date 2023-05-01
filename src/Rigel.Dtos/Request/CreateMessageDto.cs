namespace Rigel.Dtos.Request
{
    public class CreateMessageDto
    {
        [Required]
        [MinLength(1)]
        public string content { get; set; } = null!;
        [Required]
        public string postId { get; set; } = default!;
    }
}