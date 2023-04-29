namespace Rigel.Dtos.Request
{
    public class UpdateUserDto
    {
        public string? nickname { get; set; } = default!;
        public string? avatar { get; set; } = default!;
    }
}