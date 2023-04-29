using Rigel.Services.Interfaces;

namespace Rigel.Services.Impl
{
    public class CategoryService : ICategoryService
    {
        public Task<Category?> CreateCategory(CreateCategoryDto dto, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> DeleteCategory(string id, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Category> FindById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> UpdateCategory(UpdateCategoryDto dto, string userId)
        {
            throw new NotImplementedException();
        }
    }
}