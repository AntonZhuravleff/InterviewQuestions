using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechQuestions.Application.Models;
using TechQuestions.Core.Entities;
using TechQuestions.Core.Specifications;

namespace TechQuestions.Application.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionModel>> ListAsync(QuestionsFilterSpecification spec);
        Task<IEnumerable<QuestionModel>> ListAsync(QuestionsFilterPaginatedSpecification spec);
        Task<QuestionModel> GetById(int questionId);
        Task<QuestionModel> GetByIdWithTags(int questionId);
        Task SetTags(int questionId, IEnumerable<int> tagsIds);
        Task<int> CountAsync(QuestionsFilterSpecification spec);
        Task<QuestionModel> Create(QuestionModel questionModel);
        Task Update(QuestionModel questionModel);
        Task Delete(int questionId);
    }
}
