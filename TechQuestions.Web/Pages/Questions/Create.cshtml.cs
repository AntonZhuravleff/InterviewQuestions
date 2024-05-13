using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechQuestions.Web.Interfaces;
using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Pages.Questions
{
    public class CreateModel : PageModel
    {
        private readonly IQuestionViewModelService _questionViewModelService;
        private readonly ICategoryViewModelService _categoryViewModelService;

        public QuestionViewModel QuestionViewModel { get; set; } = new QuestionViewModel();

        public List<CategoryViewModel> Categories = new List<CategoryViewModel> {};

        public CreateModel(IQuestionViewModelService questionViewModelService, ICategoryViewModelService categoryViewModelService)
        {
            _questionViewModelService = questionViewModelService;
            _categoryViewModelService = categoryViewModelService;
        }

        public void OnGet()
        {
            Categories = ( _categoryViewModelService.GetAllCategories().Result).ToList();
        }

        public async Task<IActionResult> OnPostAsync(QuestionViewModel questionViewModel)
        {
            if (ModelState.IsValid)
            {
                await _questionViewModelService.AddQuestion(questionViewModel);
                return RedirectToPage("Index");
            }

            Categories = (_categoryViewModelService.GetAllCategories().Result).ToList();
            return Page();
        }
    }
}
