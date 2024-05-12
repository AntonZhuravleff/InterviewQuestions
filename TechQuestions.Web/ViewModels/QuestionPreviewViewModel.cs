namespace TechQuestions.Web.ViewModels
{
    public class QuestionPreviewViewModel
    {
        public List<TagViewModel> Tags = new List<TagViewModel>();
        public int? CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
        public string QuestionText { get; set; }
        public string ShortAnswer { get; set; }
    }
}
