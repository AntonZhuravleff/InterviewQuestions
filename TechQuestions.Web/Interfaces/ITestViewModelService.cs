using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Interfaces
{
    public interface ITestViewModelService
    {
        public Task AddTest(TestCreateViewModel testCreateViewModel);
        Task<TestsViewModel> GetTestsViewModel(int page, int questionsPerPage);
        Task<TestViewModel> GetById(int testId);
        Task AddQuestionToTest(TestQuestionViewModel testQuestion);
    }
}