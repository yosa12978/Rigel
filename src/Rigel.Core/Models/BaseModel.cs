namespace Rigel.Core.Models
{
    public class BaseModel<T>
    {
        public T id { get; set; } = default!;
    }
}