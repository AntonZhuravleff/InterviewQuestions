using TechQuestions.Application.Interfaces;
using TechQuestions.Application.Mapper;
using TechQuestions.Application.Models;
using TechQuestions.Core.Interfaces.Repositories;

namespace TechQuestions.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public async Task<IEnumerable<CategoryModel>> ListAsync()
        {
            var categories = await _categoryRepository.ListAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<CategoryModel>>(categories);
            return mapped;
        }

        public Task<CategoryModel> GetById(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryModel> Create(CategoryModel categoryModel)
        {
            throw new NotImplementedException();
        }

        public Task Update(CategoryModel categoryModel)
        {
            throw new NotImplementedException();
        }

        public Task Delete(CategoryModel categoryModel)
        {
            throw new NotImplementedException();
        }
    }
}
