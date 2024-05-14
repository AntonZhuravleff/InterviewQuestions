using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechQuestions.Core.Entities;
using TechQuestions.Web.Interfaces;
using TechQuestions.Web.Services;
using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Pages.Questions
{
    public class EditModel : PageModel
    {
        private readonly IQuestionViewModelService _questionViewModelService;
        private readonly ICategoryViewModelService _categoryViewModelService;

        public QuestionViewModel QuestionViewModel { get; set; }

        public List<CategoryViewModel> Categories = new List<CategoryViewModel> { };

        public EditModel(IQuestionViewModelService questionViewModelService, ICategoryViewModelService categoryViewModelService)
        {
            _questionViewModelService = questionViewModelService;
            _categoryViewModelService = categoryViewModelService;
        }

        public async Task OnGet(int questionId)
        {
            QuestionViewModel = await _questionViewModelService.GetQuestionById(questionId);
            Categories = (_categoryViewModelService.GetAllCategories().Result).ToList();
        }

        public async Task<IActionResult> OnPostAsync(QuestionViewModel questionViewModel)
        {
            if (ModelState.IsValid)
            {
                await _questionViewModelService.UpdateQuestion(questionViewModel);
                return RedirectToPage("/Questions/Details", new { questionId = questionViewModel.Id } );
            }

            Categories = (_categoryViewModelService.GetAllCategories().Result).ToList();
            return Page();
        }
    }
}
