using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechQuestions.Web.Interfaces;
using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Pages.Tests
{
    public class CreateModel : PageModel
    {
        private readonly ITestViewModelService _testViewModelService;

        public TestCreateViewModel TestViewModel { get; set; } = new TestCreateViewModel();

        public CreateModel(ITestViewModelService testViewModelService)
        {
            _testViewModelService = testViewModelService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(TestCreateViewModel testViewModel)
        {
            if (ModelState.IsValid)
            {
                await _testViewModelService.AddTest(testViewModel);
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}