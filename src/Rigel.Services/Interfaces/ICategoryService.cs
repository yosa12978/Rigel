namespace Rigel.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto> FindById(string id);
        Task<List<CategoryDto>> FindAll();
        Task<CategoryDto> CreateCategory(CreateCategoryDto dto, string userId);
        Task<CategoryDto> UpdateCategory(UpdateCategoryDto dto, string categoryId, string userId);
        Task<CategoryDto> DeleteCategory(string id, string userId);
    }
}