using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Interfaces
{
    public interface ICategoryRandomTestViewModelService
    {
        public Task<CategoryRandomTestViewModel> GetCategoryRandomTestViewModelAsync(int categoryId);
    }
}