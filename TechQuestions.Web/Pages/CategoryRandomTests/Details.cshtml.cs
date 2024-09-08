using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechQuestions.Web.Interfaces;
using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Pages.CategoryRandomTests
{
    public class DetailsModel : PageModel
    {
        private readonly ICategoryRandomTestViewModelService _categoryTestViewModelService;
        private readonly IQuestionViewModelService _questionViewModelService;

        public CategoryRandomTestViewModel CategoryTestViewModel { get; set; }

        public DetailsModel(ICategoryRandomTestViewModelService categoryTestViewModelService, IQuestionViewModelService questionViewModelService)
        {
            _categoryTestViewModelService = categoryTestViewModelService;
            _questionViewModelService = questionViewModelService;
        }

        public async Task OnGet(int categoryId)
        {
            CategoryTestViewModel = await _categoryTestViewModelService.GetCategoryRandomTestViewModelAsync(categoryId);
        }

        public async Task<PartialViewResult> OnGetQuestionPartial(int categoryId)
        {
            CategoryTestViewModel = await _categoryTestViewModelService.GetCategoryRandomTestViewModelAsync(categoryId);

            return Partial("_QuestionPartial", CategoryTestViewModel.CurrentQuestion);
        }
    }
}
