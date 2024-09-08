using TechQuestions.Application.Models;

namespace TechQuestions.Application.Interfaces
{
    public interface ICategoryRandomTestService
    {
        public Task<QuestionModel> GetRandomQuestion(int categoryId);
    }
}