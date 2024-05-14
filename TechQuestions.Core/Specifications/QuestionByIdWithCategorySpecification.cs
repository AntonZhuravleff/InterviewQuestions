using Ardalis.Specification;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
