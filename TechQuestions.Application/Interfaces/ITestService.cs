using TechQuestions.Application.Models;
using TechQuestions.Core.Specifications;

namespace TechQuestions.Application.Interfaces
{
    public interface ITestService
    {
        Task<IEnumerable<TestModel>> ListAsync(TestPaginatedSpecification spec);
        Task<TestModel> GetById(int testId);
        Task<int> CountAsync();
        Task<TestModel> Create(TestModel testModel);
        Task Delete(int testId);
        Task AddQuestion(int testId, int questionId);
    }
}
