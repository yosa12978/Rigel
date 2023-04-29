namespace Rigel.Dtos.Request
{
    public class CreatePostDto
    {
        [Required]
        public string subject { get; set; } = default!;
        [Required]
        public string categoryId { get; set; } = default!;
    }
}