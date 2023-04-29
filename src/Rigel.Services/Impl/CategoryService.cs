using Rigel.Services.Interfaces;

namespace Rigel.Services.Impl
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IIdGenerator _idgen;
        public CategoryService(ICategoryRepository categoryRepository, IIdGenerator idgen)
        {
            _categoryRepository = categoryRepository;
            _idgen = idgen;
        }
        public Task<CategoryDto> CreateCategory(CreateCategoryDto dto, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDto> DeleteCategory(string id, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoryDto>> FindAll()
        {
            List<Category> categories = await _categoryRepository.FindAll();
            return await Task.Run(() => categories.Select(x => CategoryDto.MapToDto(x)).ToList());
        }

        public async Task<CategoryDto> FindById(string id)
        {
            Category? category = await _categoryRepository.FindById(id);
            if (category == null)
                throw new NotFoundException("category not found");
            return CategoryDto.MapToDto(category);
        }

        public Task<CategoryDto> UpdateCategory(UpdateCategoryDto dto, string userId)
        {
            throw new NotImplementedException();
        }
    }
}