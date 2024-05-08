using TechQuestions.Application.Models;

namespace TechQuestions.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> ListAsync();
        Task<CategoryModel> GetById(int categoryId);
        Task<CategoryModel> Create(CategoryModel categoryModel);
        Task Update(CategoryModel categoryModel);
        Task Delete(CategoryModel categoryModel);
    }
}
