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
        public async Task<CategoryDto> CreateCategory(CreateCategoryDto dto, string userId)
        {
            Category category = new Category
            {
                id = _idgen.NewId(),
                name = dto.name,
            };
            // todo do smth with userid;
            return CategoryDto.MapToDto(await _categoryRepository.Create(category));
        }

        public async Task<CategoryDto> DeleteCategory(string id, string userId)
        {
            Category? category = await _categoryRepository.FindById(id);
            if (category == null) // todo do smth with userid
                throw new NotFoundException("category not found");
            return CategoryDto.MapToDto(await _categoryRepository.Delete(category));
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

        public async Task<CategoryDto> UpdateCategory(UpdateCategoryDto dto, string categoryId, string userId)
        {
            Category? category = await _categoryRepository.FindById(categoryId);
            if (category == null) // todo do smth with userid
                throw new NotFoundException("category not found");
            category.name = dto.name;
            return CategoryDto.MapToDto(await _categoryRepository.Update(category));
        }
    }
}