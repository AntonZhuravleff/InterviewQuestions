using Ardalis.Specification;
using TechQuestions.Core.Entities;

namespace TechQuestions.Core.Specifications
{
    public class TestPaginatedSpecification : Specification<Test>
    {
        public TestPaginatedSpecification(int skip, int take) : base()
        {
            if (take == 0)
            {
                take = int.MaxValue;
            }
            Query.Skip(skip).Take(take);
        }
    }
}