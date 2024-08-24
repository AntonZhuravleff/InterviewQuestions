using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechQuestions.Web.Interfaces;
using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Pages.Questions
{
    public class AddToTestModel : PageModel
    {
        private readonly ITestViewModelService _testViewModelService;

        [BindProperty(SupportsGet = true)]
        public TestQuestionViewModel TestQuestionViewModel { get; set; }
    
        public TestsViewModel TestsViewModel { get; set; }

        public AddToTestModel(ITestViewModelService testViewModelService)
        {
            _testViewModelService = testViewModelService;
        }

        public async Task OnGet(int questionId, int? pageId)
        {
            TempData["TestQuestionId"] = questionId;
            
            TestsViewModel = await _testViewModelService.GetTestsViewModel(pageId ?? 0, 5);
        }

        public async Task<IActionResult> OnPostAddQuestionAsync(TestQuestionViewModel testQuestionViewModel)
        {
            if (TempData.ContainsKey("TestQuestionId") && TempData["TestQuestionId"] != null)
            {
                testQuestionViewModel.QuestionId = (int)TempData["TestQuestionId"];
                if (testQuestionViewModel.TestId > 0 && testQuestionViewModel.QuestionId > 0)
                {
                    await _testViewModelService.AddQuestionToTest(testQuestionViewModel);
                }
            }

            return Redirect("/Questions/Index");       
        }
    }
}