using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Interfaces
{
    public interface ICategoryViewModelService
    {
        public Task<IEnumerable<CategoryViewModel>> GetAllCategories();
    }
}
