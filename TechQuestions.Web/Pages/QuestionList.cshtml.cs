using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechQuestions.Web.Interfaces;
using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Pages
{
    public class QuestionListModel : PageModel
    {  
          private readonly IQuestionViewModelService _questionViewModelService;
          public QuestionListViewModel QuestionsViewModel { get; set; }

          public QuestionListModel(IQuestionViewModelService questionViewModelService)
          {
              _questionViewModelService = questionViewModelService;
          }

          public async Task OnGet(int? pageId)
          {
              QuestionsViewModel = await _questionViewModelService.GetQuestionsViewModel(pageId ?? 0, 20, null, null);
          }
    }
}