namespace Rigel.Core.Models
{
    public class Category : BaseModel<string>
    {
        public string name { get; set; } = default!;
        public List<Post> posts { get; set; } = default!;
    }
}