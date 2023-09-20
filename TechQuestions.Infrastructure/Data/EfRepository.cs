using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechQuestions.Core.Entities;
using TechQuestions.Core.Interfaces;

namespace TechQuestions.Infrastructure.Data
{
    public class EfRepository<T> : RepositoryBase<T>, IRepository<T> where T : BaseEntity
    {
        public EfRepository(QuestionsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
