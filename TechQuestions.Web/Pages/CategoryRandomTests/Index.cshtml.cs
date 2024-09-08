using Microsoft.AspNetCore.Mvc.RazorPages;
using TechQuestions.Web.Interfaces;
using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Pages.CategoryRandomTests
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryViewModelService _categoryViewModelService;

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();

        public IndexModel(ICategoryViewModelService categoryViewModelService)
        {
            _categoryViewModelService = categoryViewModelService;
        }

        public async Task OnGet()
        {
            Categories = await _categoryViewModelService.GetAllCategories();
        }
    }
}