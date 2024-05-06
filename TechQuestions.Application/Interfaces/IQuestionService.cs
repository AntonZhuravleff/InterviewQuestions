using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechQuestions.Application.Models;
using TechQuestions.Core.Entities;

namespace TechQuestions.Application.Interfaces
{
    public interface IQuestionService
    {
        Task<QuestionModel> GetQuestionById(int questionId);
        Task<IEnumerable<QuestionModel>> GetQuestionByCategory(int categoryId);
        Task<QuestionModel> Create(QuestionModel questionModel);
        Task Update(QuestionModel questionModel);
        Task Delete(QuestionModel questionModel);
    }
}
