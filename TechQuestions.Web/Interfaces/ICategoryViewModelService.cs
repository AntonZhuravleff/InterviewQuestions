using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Interfaces
{
    public interface ICategoryViewModelService
    {
        public Task<IEnumerable<CategoryViewModel>> GetAllCategories();

        public Task<CategoriesViewModel> GetCategoriesViewModel();

        public Task<CategoryViewModel> GetCategoryById(int id);  

        public Task AddCategory(CategoryAddViewModel categoryViewModel);
    }
}
