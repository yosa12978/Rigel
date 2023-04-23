namespace Rigel.Core 
{
    public class Thread : BaseModel<string>
    {
        public string categoryId { get; set; } = default!;
        public Category category { get; set; } = default!;
        public string? subject { get; set; } = default!;
        public List<Post> posts { get; set; } = default!;
    }
}