using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using DAL.Tools;

namespace BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            return categories;
        }
    }
}
