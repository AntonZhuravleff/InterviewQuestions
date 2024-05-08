using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Interfaces
{
    public interface IQuestionViewModelService
    {
        public Task<QuestionListViewModel> GetQuestionsViewModel(int page, int questionsPerPage, int? categoryId, List<int>? tagIds);
    }
}
