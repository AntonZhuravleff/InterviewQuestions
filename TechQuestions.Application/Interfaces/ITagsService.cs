using TechQuestions.Application.Models;

namespace TechQuestions.Application.Interfaces
{
    public interface ITagsService
    {
        Task<IEnumerable<TagModel>> ListAsync();
        Task<TagModel> GetById(int tagId);
        Task<TagModel> Create(TagModel tagModel);
        Task Update(TagModel tagModel);
        Task Delete(TagModel tagModel);
    }
}
