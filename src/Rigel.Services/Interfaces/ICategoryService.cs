namespace Rigel.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> FindById(string id);
        Task<List<Category>> FindAll();
        Task<Category> CreateCategory(CreateCategoryDto dto, string userId);
        Task<Category> UpdateCategory(UpdateCategoryDto dto, string userId);
        Task<Category> DeleteCategory(string id, string userId);
    }
}