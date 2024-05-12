using AutoMapper;
using System.Collections.Generic;
using TechQuestions.Application.Interfaces;
using TechQuestions.Core.Entities;
using TechQuestions.Core.Specifications;
using TechQuestions.Web.Interfaces;
using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Services
{
    public class QuestionViewModelService : IQuestionViewModelService
    {
        private readonly ICategoryService _categoryAppService;
        private readonly ITagsService _tagsAppService;
        private readonly IQuestionService _questionAppService;
        
        private readonly IMapper _mapper;

        public QuestionViewModelService(
            ICategoryService categoryAppService, 
            ITagsService tagsAppService, 
            IQuestionService questionAppService, 
            IMapper mapper)
        {
            _categoryAppService = categoryAppService;
            _tagsAppService = tagsAppService;
            _questionAppService = questionAppService;
            _mapper = mapper;
        }


        public async Task<QuestionsViewModel> GetQuestionsViewModel(int page, int questionsPerPage, int? categoryId, List<int>? tagIds)
        {
            var filterSpecification = new QuestionsFilterPaginatedSpecification(page * questionsPerPage, questionsPerPage, categoryId, tagIds);
            var questions = await _questionAppService.ListAsync(filterSpecification);
            var mappedQuestions = _mapper.Map<IEnumerable<QuestionPreviewViewModel>>(questions);

            var categories = await _categoryAppService.ListAsync();
            var mappedCategories = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);

            var questionsVM = new QuestionsViewModel()
            {
                Categories = mappedCategories,
                Questions = mappedQuestions
            };

            return questionsVM;
        }
    }
}
