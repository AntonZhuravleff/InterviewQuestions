using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TechQuestions.Web.Interfaces;
using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Pages.Categories
{
    [DisableRequestSizeLimit]
    [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
    public class IndexModel : PageModel
    {
        private readonly ICategoryViewModelService _categoryViewModelService;

        public CategoriesViewModel CategoriesViewModel { get; set; }

        [BindProperty]
        public CategoryAddViewModel CategoryToAdd { get; set; }

        public IndexModel(ICategoryViewModelService categoryViewModelService)
        {
            _categoryViewModelService = categoryViewModelService;
        }

        public async Task OnGet()
        {
            CategoriesViewModel = await _categoryViewModelService.GetCategoriesViewModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _categoryViewModelService.AddCategory(CategoryToAdd);
                return RedirectToPage("Index");
            }

            CategoriesViewModel = await _categoryViewModelService.GetCategoriesViewModel();
            return Page();
        }
    }
}
