namespace Rigel.Dtos.Response
{
    public class CategoryDto 
    {
        public string id { get; set; } = default!;
        public string name { get; set; } = default!;
        // public List<PostResDto> posts { get; set; } = default!;

        public static Category MapToObj(CategoryDto dto) 
        {
            return new Category
            {
                id = dto.id,
                name = dto.name,
            };
        }

        public static CategoryDto MapToDto(Category obj)
        {
            return new CategoryDto
            {
                id = obj.id,
                name = obj.name,
            };
        }
    }
}