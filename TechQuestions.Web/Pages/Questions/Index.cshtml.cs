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


        public IndexModel(IQuestionViewModelService questionViewModelService)
        {       
            _questionViewModelService = questionViewModelService;
        }

        public async Task OnGet(int? pageId, int selectedCategoryId)
        {
           int? selectedCategory = null;
           if (TempData.ContainsKey("SelectedCategoryId"))
           {
               selectedCategory = (int)TempData["SelectedCategoryId"];
           }

           QuestionsViewModel = await _questionViewModelService.GetQuestionsViewModel(pageId ?? 0, 5, selectedCategory, null);
        }

        public async Task<IActionResult> OnPostSearchAsync(QuestionsViewModel questionsViewModel)
        {
            int selectedCategoryid = questionsViewModel.SelectedCategoryId;    
            if (selectedCategoryid > 0)
            {
                QuestionsViewModel = await _questionViewModelService.GetQuestionsViewModel(0, 5, selectedCategoryid, null);
            }

            TempData["SelectedCategoryId"] = selectedCategoryid;
            return Page();
        }
    }
}