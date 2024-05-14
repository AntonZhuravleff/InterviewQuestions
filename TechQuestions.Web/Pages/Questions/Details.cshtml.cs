using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechQuestions.Web.Interfaces;
using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Pages.Questions
{
    public class DetailsModel : PageModel
    {
        private readonly IQuestionViewModelService _questionViewModelService;

        public QuestionViewModel QuestionViewModel { get; set; }

        public DetailsModel(IQuestionViewModelService questionViewModelService)
        {
            _questionViewModelService = questionViewModelService;
        }

        public async Task OnGet(int questionId)
        {
            QuestionViewModel = await _questionViewModelService.GetQuestionById(questionId);
        }
    }
}
