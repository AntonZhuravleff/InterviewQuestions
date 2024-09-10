namespace TechQuestions.Web.ViewModels
{
    public class TagsViewModel
    {
        public IEnumerable<TagViewModel> Tags { get; set; }

        public int TagToDelete { get; set; }
    }
}