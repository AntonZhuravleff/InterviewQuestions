using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Interfaces
{
    public interface ITagsViewModelService
    {
        public Task<IEnumerable<TagViewModel>> GetAllTags();

        public Task<TagsViewModel> GetTagsViewModel();

        public Task AddTag(TagViewModel tagViewModel);

        public Task DeleteTag(int tagId);
    }
}