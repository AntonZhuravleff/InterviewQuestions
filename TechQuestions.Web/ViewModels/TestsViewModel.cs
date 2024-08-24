namespace TechQuestions.Web.ViewModels
{
    public class TestsViewModel
    {
        public IEnumerable<TestPreviewViewModel> Tests { get; set; }

        public PaginationInfoViewModel PaginationInfo { get; set; }
    }
}