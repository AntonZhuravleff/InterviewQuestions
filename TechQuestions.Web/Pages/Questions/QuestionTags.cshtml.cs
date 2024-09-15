using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechQuestions.Web.Interfaces;
using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Pages.Questions
{
    public class QuestionTagsModel : PageModel
    {
        private readonly IQuestionViewModelService _questionViewModelService;
        private readonly ITagsViewModelService _tagsViewModelService;

        public QuestionViewModel QuestionWithTags { get; set; }
        public IEnumerable<TagViewModel> Tags { get; set; }

        [BindProperty]
        public IEnumerable<int> SelectedTagsIds { get; set; }

        public QuestionTagsModel(IQuestionViewModelService questionViewModelService, ITagsViewModelService tagsViewModelService)
        {
            _questionViewModelService = questionViewModelService;
            _tagsViewModelService = tagsViewModelService;
        }

        public async Task OnGet(int questionId)
        {
            QuestionWithTags = await _questionViewModelService.GetQuestionByIdWithTags(questionId);
            Tags = await _tagsViewModelService.GetAllTags();
            SelectedTagsIds = QuestionWithTags.Tags.Select(t => t.Id).ToList();
        }

        public async Task<IActionResult>  OnPostSelectTags(int questionId)
        {
            await _questionViewModelService.SetQuestionTags(questionId, SelectedTagsIds);

            return  RedirectToPage(new { questionId = questionId});
        }
    }
}
