using TechQuestions.Application.Models;
using TechQuestions.Web.ViewModels.Base;

namespace TechQuestions.Web.ViewModels
{
    public class QuestionViewModel : BaseViewModel
    {
        public List<TagViewModel> Tags = new List<TagViewModel>();
        public int? CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
        public string QuestionText { get; set; }
        public string ShortAnswer { get; set; }
        public string Answer { get; set; }
    }
}
