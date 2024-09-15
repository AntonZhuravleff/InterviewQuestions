using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Interfaces
{
    public interface IQuestionViewModelService
    {
        public Task<QuestionViewModel> GetQuestionById(int id);
        public Task<QuestionViewModel> GetQuestionByIdWithTags(int id);
        public Task<QuestionsViewModel> GetQuestionsViewModel(int page, int questionsPerPage, int? categoryId, List<int>? tagIds);
        public Task AddQuestion(QuestionViewModel questionViewModel);
        public Task UpdateQuestion(QuestionViewModel questionViewModel);
        public Task DeleteQuestion(int questionId);
        public Task SetQuestionTags(int questionId, IEnumerable<int> tagsIds);
    }
}
