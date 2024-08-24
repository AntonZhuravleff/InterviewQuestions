using TechQuestions.Application.Interfaces;
using TechQuestions.Application.Models;
using TechQuestions.Core.Entities;
using TechQuestions.Core.Interfaces.Repositories;
using TechQuestions.Application.Mapper;
using TechQuestions.Core.Specifications;

namespace TechQuestions.Application.Services
{
    public class TestService : ITestService
    {

        private readonly ITestRepository _testRepository;
        private readonly IQuestionRepository _questionRepository;

        public TestService(ITestRepository testRepository, IQuestionRepository questionRepository)
        {
            _testRepository = testRepository ?? throw new ArgumentNullException(nameof(testRepository));
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
        }

        public async Task<IEnumerable<TestModel>> ListAsync(TestPaginatedSpecification spec)
        {
            var tests = await _testRepository.ListAsync(spec);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<TestModel>>(tests);
            return mapped;
        }

        public async Task<TestModel> GetById(int testId)
        {
            var testWithQuestionsSpec = new TestByIdWithQuestionsSpecification(testId);

            var test = await _testRepository.GetBySpecAsync(testWithQuestionsSpec);
            var mapped = ObjectMapper.Mapper.Map<TestModel>(test);
            return mapped;
        }

        public async Task<int> CountAsync()
        {
            return await _testRepository.CountAsync();
        }

        public async Task<TestModel> Create(TestModel testModel)
        {
            var mappedTest = ObjectMapper.Mapper.Map<Test>(testModel);
            var newTest = await _testRepository.AddAsync(mappedTest);

            var newTestMapped = ObjectMapper.Mapper.Map<TestModel>(newTest);
            return newTestMapped;
        }

        public async Task AddQuestion(int testId, int questionId)
        {
            var test = await _testRepository.GetByIdAsync(testId);
            var question = await _questionRepository.GetByIdAsync(questionId);

            test.AddQuestion(question);
            await _testRepository.UpdateAsync(test);
        }

        public async Task Delete(int testId)
        {
            var testToDelete = await _testRepository.GetByIdAsync(testId);
            await _testRepository.DeleteAsync(testToDelete);
        }
    }
}
