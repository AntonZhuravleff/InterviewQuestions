using Ardalis.Specification;
using TechQuestions.Core.Entities;

namespace TechQuestions.Core.Specifications
{
    public class TestByIdWithQuestionsSpecification : Specification<Test>
    {
        public TestByIdWithQuestionsSpecification(int testId) : base()
        {
            Query
                .Where(t => t.Id == testId)
                .Include(t => t.Questions);
        }
    }
}