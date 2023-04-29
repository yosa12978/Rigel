namespace Rigel.Dtos.Request
{
    public class CreateCategoryDto
    {
        [Required]
        public string name { get; set; } = default!;
        public string shortcut { get; set; } = default!; // ??
    }
}