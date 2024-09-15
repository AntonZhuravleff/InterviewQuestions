using Ardalis.Specification;
using TechQuestions.Core.Entities;

namespace TechQuestions.Core.Specifications
{
    public class QuestionByIdWithCategoryAndTagsSpecification : Specification<Question>
    {
        public QuestionByIdWithCategoryAndTagsSpecification(int questionId) : base() 
        {
            Query
                .Where(q => q.Id == questionId)
                .Include(q => q.Category)
                .Include(q => q.Tags);
        }    
    }
}
