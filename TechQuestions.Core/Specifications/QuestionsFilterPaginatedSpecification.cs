using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechQuestions.Core.Entities;

namespace TechQuestions.Core.Specifications
{
    public class QuestionsFilterPaginatedSpecification : Specification<Question>
    {
        public QuestionsFilterPaginatedSpecification(int skip, int take, int? categoryId,  List<int>? tagIds) : base()
        {
            if (take == 0)
            {
                take = int.MaxValue;
            }
            Query
                .Where(q => (tagIds == null || tagIds.Contains(q.Id)) &&
                (!categoryId.HasValue || q.CategoryId == categoryId))
                .Skip(skip).Take(take)
                .Include(q => q.Category);
            
        }
    }
}
