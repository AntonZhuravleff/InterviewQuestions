using Ardalis.Specification;
using TechQuestions.Core.Entities;

namespace TechQuestions.Core.Specifications
{
    public class QuestionsFilterSpecification : Specification<Question>
    {
        public QuestionsFilterSpecification(int? categoryId, List<int>? tagIds) : base()
        {
            Query
                .Where(q => (tagIds == null || tagIds.Contains(q.Id)) &&
                (!categoryId.HasValue || q.CategoryId == categoryId))
                .Include(q => q.Category)
                .Include(q => q.Tags);
        }
    }
}
