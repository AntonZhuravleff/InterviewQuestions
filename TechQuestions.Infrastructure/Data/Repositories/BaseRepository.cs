using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechQuestions.Core.Entities;
using TechQuestions.Core.Interfaces;
using TechQuestions.Core.Interfaces.Repositories;

namespace TechQuestions.Infrastructure.Data.Repositories
{
    public class BaseRepository<T> : RepositoryBase<T>, IRepository<T> where T : BaseEntity
    {
        protected readonly QuestionsDbContext _dbContext;
        public BaseRepository(QuestionsDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }
}
