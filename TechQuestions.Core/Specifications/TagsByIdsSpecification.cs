using Ardalis.Specification;
using TechQuestions.Core.Entities;

namespace TechQuestions.Core.Specifications
{
    public class TagsByIdsSpecification : Specification<Tag>
    {
        public TagsByIdsSpecification(List<int> tagIds) : base()
        {
            Query.Where(q => tagIds.Contains(q.Id));
        }
    }
}