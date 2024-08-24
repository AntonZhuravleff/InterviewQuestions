using Microsoft.AspNetCore.Mvc.RazorPages;
using TechQuestions.Web.Interfaces;
using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Pages.Tests
{
    public class DetailsModel : PageModel
    {
        private readonly ITestViewModelService _testViewModelService;

        public TestViewModel TestViewModel { get; set; }

        public DetailsModel(ITestViewModelService testViewModelService)
        {
            _testViewModelService = testViewModelService;
        }

        public async Task OnGet(int testId)
        {
            TestViewModel = await _testViewModelService.GetById(testId);
        }
    }
}