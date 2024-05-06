using TechQuestions.Application.Models;

namespace TechQuestions.Web.ViewModels
{
    public class QuestionViewModel
    {
        public List<TagViewModel> Tags = new List<TagViewModel>();
        public int? CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
        public string QuestionText { get; set; }
        public string Answer { get; set; }
    }
}
