using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechQuestions.Core.Entities;

namespace TechQuestions.Core.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : BaseEntity
    {
    }
}
