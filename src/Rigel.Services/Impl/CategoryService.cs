using Microsoft.Extensions.Logging;
using Rigel.Services.Interfaces;

namespace Rigel.Services.Impl
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IIdGenerator _idgen;
        private readonly ILogger<CategoryService> _logger;
        public CategoryService(ICategoryRepository categoryRepository, 
                            IIdGenerator idgen, 
                            ILogger<CategoryService> logger,
                            IUserRepository userRepository)
        {
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _idgen = idgen;
            _logger = logger;
        }
        public async Task<CategoryDto> CreateCategory(CreateCategoryDto dto, string userId)
        {
            if (!(await _userRepository.IsUserAdmin(userId)))
                throw new ForbiddenException("forbidden");
            Category category = new Category
            {
                id = _idgen.NewId(),
                name = dto.name,
            };
            _logger.LogInformation($"creating category with id = {category.id}");
            return CategoryDto.MapToDto(await _categoryRepository.Create(category));
        }

        public async Task<CategoryDto> DeleteCategory(string id, string userId)
        {
            if (!(await _userRepository.IsUserAdmin(userId)))
                throw new ForbiddenException("forbidden");
            Category? category = await _categoryRepository.FindById(id);
            if (category == null)
                throw new NotFoundException("category not found");
            _logger.LogInformation($"deleting category with id = {category.id}");
            return CategoryDto.MapToDto(await _categoryRepository.Delete(category));
        }

        public async Task<List<CategoryDto>> FindAll()
        {
            List<Category> categories = await _categoryRepository.FindAll();
            _logger.LogInformation("returning all categories");
            return await Task.Run(() => categories.Select(x => CategoryDto.MapToDto(x)).ToList());
        }

        public async Task<CategoryDto> FindById(string id)
        {
            Category? category = await _categoryRepository.FindById(id);
            if (category == null)
                throw new NotFoundException("category not found");
            _logger.LogInformation($"returning category with id = {category.id}");
            return CategoryDto.MapToDto(category);
        }

        public async Task<CategoryDto> UpdateCategory(UpdateCategoryDto dto, string categoryId, string userId)
        {
            if (!(await _userRepository.IsUserAdmin(userId)))
                throw new ForbiddenException("forbidden");
            Category? category = await _categoryRepository.FindById(categoryId);
            if (category == null)
                throw new NotFoundException("category not found");
            category.name = dto.name;
            _logger.LogInformation($"updating category with id = {category.id}");
            return CategoryDto.MapToDto(await _categoryRepository.Update(category));
        }
    }
}