namespace Rigel.Core 
{
    public class Category : BaseModel<string>
    {
        public string name { get; set; } = default!;
        public List<Thread> threads { get; set; } = default!;
        public string shortcut { get; set; } = default!;
    }
}