using Microsoft.AspNetCore.Mvc.RazorPages;
using TechQuestions.Web.Interfaces;
using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Pages.Tests
{
    public class IndexModel : PageModel
    {
        private readonly ITestViewModelService _testViewModelService;

        public TestsViewModel TestsViewModel { get; set; }

        public IndexModel(ITestViewModelService testViewModelService)
        {
            _testViewModelService = testViewModelService;
        }

        public async Task OnGet(int? pageId)
        {
            TestsViewModel = await _testViewModelService.GetTestsViewModel(pageId ?? 0, 5);
        }
    }
}