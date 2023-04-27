namespace Rigel.Dtos
{
    public class CategoryDto 
    {
        public string id { get; set; } = default!;
        public string name { get; set; } = default!;
        // public List<PostResDto> posts { get; set; } = default!;
        public string shortcut { get; set; } = default!;
        public bool IsValid() 
        {
            return true;
        }
    }
}