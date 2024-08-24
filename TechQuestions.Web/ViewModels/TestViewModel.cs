namespace TechQuestions.Web.ViewModels
{
    public class TestViewModel
    {
        public List<QuestionViewModel> Questions = new List<QuestionViewModel>();
        public int CurrentQuestionIndex { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }   
    }
}