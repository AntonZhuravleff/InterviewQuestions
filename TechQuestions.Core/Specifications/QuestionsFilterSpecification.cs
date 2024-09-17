using Ardalis.Specification;
using TechQuestions.Core.Entities;

namespace TechQuestions.Core.Specifications
{
    public class QuestionsFilterSpecification : Specification<Question>
    {
        public QuestionsFilterSpecification(int? categoryId, List<int>? tagIds) : base()
        {
            Query
                .Where(q => ((tagIds == null) || (tagIds.Count == 0) || (q.Tags.Select(t => t.Id).Where(t => tagIds.Contains(t)).Count() > 0)) &&
                (!categoryId.HasValue || q.CategoryId == categoryId))
                .Include(q => q.Category)
                .Include(q => q.Tags);
        }
    }
}
