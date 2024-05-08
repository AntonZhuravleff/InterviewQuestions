using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechQuestions.Core.Entities;
using TechQuestions.Core.Interfaces.Repositories;

namespace TechQuestions.Infrastructure.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(QuestionsDbContext dbContext) : base(dbContext){}
    }
}
