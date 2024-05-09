namespace TechQuestions.Web.ViewModels
{
    public class QuestionsViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }
        public IEnumerable<TagViewModel> Tags { get; set; }
        public IEnumerable<QuestionViewModel> Questions { get; set; }
        public PaginationInfoViewModel PaginationInfo { get; set; }
    }
}
