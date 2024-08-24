using Ardalis.Specification;
using TechQuestions.Core.Entities;

namespace TechQuestions.Core.Specifications
{
    public class QuestionByIdWithCategorySpecification : Specification<Question>
    {
        public QuestionByIdWithCategorySpecification(int questionId) : base() 
        {
            Query
                .Where(q => q.Id == questionId)
                .Include(q => q.Category);
        }    
    }
}
