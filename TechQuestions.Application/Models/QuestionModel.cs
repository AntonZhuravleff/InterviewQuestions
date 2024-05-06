using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechQuestions.Core.Entities;

namespace TechQuestions.Application.Models
{
    public class QuestionModel : BaseModel
    {
        public List<TagModel> Tags = new List<TagModel>();
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        public string QuestionText { get; set; }
        public string Answer { get; set; }
    }
}
