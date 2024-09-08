using TechQuestions.Application.Interfaces;
using TechQuestions.Application.Models;
using TechQuestions.Core.Specifications;

namespace TechQuestions.Application.Services
{
    public class CategoryRandomTestService : ICategoryRandomTestService
    {
        private readonly IQuestionService _questionAppService;

        public CategoryRandomTestService(IQuestionService questionAppService)
        {
            _questionAppService = questionAppService;
        }

        public async Task<QuestionModel> GetRandomQuestion(int categoryId)
        {
            if (categoryId < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(categoryId));
            }

            int count = await _questionAppService.CountAsync(new QuestionsFilterSpecification(categoryId, null));
            int questionsToSkip = new Random().Next(0, count);

            if (count > 0)
            {
                return (await _questionAppService.ListAsync(new QuestionsFilterPaginatedSpecification(questionsToSkip, 1, categoryId, null))).First();
            }
            else
            {
                return new QuestionModel();
            }
        }
    }
}