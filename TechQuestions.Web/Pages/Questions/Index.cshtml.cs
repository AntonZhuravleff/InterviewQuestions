using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechQuestions.Web.Interfaces;
using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Pages.Questions
{
    public class IndexModel : PageModel
    {
        private readonly IQuestionViewModelService _questionViewModelService;

        public QuestionsViewModel QuestionsViewModel { get; set; }

        [BindProperty]
        public int? SelectedCategoryId { get; set; }

        [BindProperty]
        public IEnumerable<int> SelectedTagsIds { get; set; }

        public IndexModel(IQuestionViewModelService questionViewModelService)
        {
            _questionViewModelService = questionViewModelService;
        }

        public async Task OnGet(int? pageId, int? categoryId, IEnumerable<int>? tagsIds)
        {
            QuestionsViewModel = await _questionViewModelService.GetQuestionsViewModel(pageId ?? 0, 5, categoryId, tagsIds?.ToList());
        }

        public async Task<IActionResult> OnPostSearchAsync()
        {
            return RedirectToPage(new { pageId = 0, categoryId = SelectedCategoryId, tagsIds = SelectedTagsIds });
        }
    }
}