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

          public IndexModel(IQuestionViewModelService questionViewModelService)
          {
              _questionViewModelService = questionViewModelService;
          }

          public async Task OnGet(int? pageId)
          {
              QuestionsViewModel = await _questionViewModelService.GetQuestionsViewModel(pageId ?? 0, 20, null, null);
          }
    }
}