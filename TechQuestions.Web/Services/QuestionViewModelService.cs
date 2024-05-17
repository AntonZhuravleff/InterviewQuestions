using AutoMapper;
using System.Collections.Generic;
using TechQuestions.Application.Interfaces;
using TechQuestions.Application.Models;
using TechQuestions.Core.Entities;
using TechQuestions.Core.Specifications;
using TechQuestions.Web.Interfaces;
using TechQuestions.Web.Pages;
using TechQuestions.Web.ViewModels;
using QuestionModel = TechQuestions.Application.Models.QuestionModel;

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

        public async Task<QuestionViewModel> GetQuestionById(int id)
        {
           var question = await _questionAppService.GetById(id);

            var mappedQuestion = _mapper.Map<QuestionViewModel>(question);
            return mappedQuestion;
        }

        public async Task<QuestionsViewModel> GetQuestionsViewModel(int page, int questionsPerPage, int? categoryId, List<int>? tagIds)
        {

            var filterPaginatedSpecification = new QuestionsFilterPaginatedSpecification(page * questionsPerPage, questionsPerPage, categoryId, tagIds);
            var filterSpecification = new QuestionsFilterSpecification(categoryId, tagIds);

            var questions = await _questionAppService.ListAsync(filterPaginatedSpecification);
            var totalCount = await _questionAppService.CountAsync(filterSpecification);

            var mappedQuestions = _mapper.Map<IEnumerable<QuestionPreviewViewModel>>(questions);

            var categories = await _categoryAppService.ListAsync();
            var mappedCategories = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);

            var questionsVM = new QuestionsViewModel()
            {
                Categories = mappedCategories,
                Questions = mappedQuestions,
                PaginationInfo = new PaginationInfoViewModel()
                {
                    ActualPage = page,
                    ItemsPerPage = questions.Count(),
                    TotalItems = totalCount,
                    TotalPages = int.Parse(Math.Ceiling(((decimal)totalCount / questionsPerPage)).ToString()),
                }
            };

            questionsVM.PaginationInfo.Next = (questionsVM.PaginationInfo.ActualPage == questionsVM.PaginationInfo.TotalPages - 1) ? 
                "page-container__link_disabled" : "page-container__link-next";

            questionsVM.PaginationInfo.Previous = (questionsVM.PaginationInfo.ActualPage == 0) ? 
                "page-container__link_disabled" : "page-container__link-previous";

            return questionsVM;
        }

        public async Task AddQuestion(QuestionViewModel questionViewModel)
        {
            var mappedQuestion = _mapper.Map<QuestionModel>(questionViewModel);

            await _questionAppService.Create(mappedQuestion);
        }

        public async Task UpdateQuestion(QuestionViewModel questionViewModel)
        {
            var mappedQuestion = _mapper.Map<QuestionModel>(questionViewModel);

            await _questionAppService.Update(mappedQuestion);
        }

        public async Task DeleteQuestion(int questionId)
        {
            await _questionAppService.Delete(questionId);
        }
    }
}
