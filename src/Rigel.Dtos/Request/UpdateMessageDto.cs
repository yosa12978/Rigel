namespace Rigel.Dtos.Request
{
    public class UpdateMessageDto
    {
        [Required]
        [MinLength(1)]
        public string content { get; set; } = null!;
    }
}