using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechQuestions.Core.Entities;
using TechQuestions.Core.Interfaces.Repositories;

namespace TechQuestions.Infrastructure.Data.Repositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(QuestionsDbContext dbContext) : base(dbContext) {}
        public async Task<IEnumerable<Question>> GetQuestionByCategoryAsync(int categoryId)
        {
            return await _dbContext.Questions
            .Where(x => x.CategoryId == categoryId)
            .ToListAsync();
        }
    }
}
