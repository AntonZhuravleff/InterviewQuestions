using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechQuestions.Core.Entities;

namespace TechQuestions.Core.Interfaces.Repositories
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task<IEnumerable<Question>> GetQuestionByCategoryAsync(int categoryId);
    }
}
