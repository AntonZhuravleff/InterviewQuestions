using Ardalis.Specification;
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
                .Where(q => ((tagIds == null) || (tagIds.Count == 0) || (q.Tags.Select(t=> t.Id).Where(t => tagIds.Contains(t)).Count() > 0)) &&
                (!categoryId.HasValue || q.CategoryId == categoryId))
                .Skip(skip).Take(take)
                .Include(q => q.Category)
                .Include(q => q.Tags);
        }
    }
}
