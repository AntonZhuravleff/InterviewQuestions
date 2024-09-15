using Ardalis.Specification;
using TechQuestions.Core.Entities;

namespace TechQuestions.Core.Specifications
{
    public class QuestionByIdWithTagsSpecification : Specification<Question>
    {
        public QuestionByIdWithTagsSpecification(int questionId) : base()
        {
            Query
                .Where(q => q.Id == questionId)
                .Include(q => q.Tags);
        }
    }
}
