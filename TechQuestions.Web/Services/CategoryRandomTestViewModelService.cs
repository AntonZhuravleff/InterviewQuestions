using AutoMapper;
using TechQuestions.Application.Interfaces;
using TechQuestions.Core.Specifications;
using TechQuestions.Web.Interfaces;
using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Services
{
    public class CategoryRandomTestViewModelService : ICategoryRandomTestViewModelService
    {
        private readonly ICategoryRandomTestService _categoryRandomTestAppService;
        private readonly IQuestionService _questionAppService;
        private readonly ICategoryViewModelService _categoryViewModelService;
        private readonly IMapper _mapper;

        public CategoryRandomTestViewModelService(ICategoryRandomTestService categoryRandomTestAppService, IQuestionService questionAppService,
            ICategoryViewModelService categoryViewModelService, IMapper mapper)
        {
            _categoryRandomTestAppService = categoryRandomTestAppService;
            _questionAppService = questionAppService;
            _categoryViewModelService = categoryViewModelService;
            _mapper = mapper;
        }

        public async Task<CategoryRandomTestViewModel> GetCategoryRandomTestViewModelAsync(int categoryId)
        {
            var categoryRandomTestVM = new CategoryRandomTestViewModel();
       
            categoryRandomTestVM.CategoryViewModel = await _categoryViewModelService.GetCategoryById(categoryId);
            categoryRandomTestVM.TotalCount = await _questionAppService.CountAsync(new QuestionsFilterSpecification(categoryId, null));

            var question = await _categoryRandomTestAppService.GetRandomQuestion(categoryId);
            categoryRandomTestVM.CurrentQuestion = _mapper.Map<QuestionViewModel>(question);

            return categoryRandomTestVM;
        }
    }
}
