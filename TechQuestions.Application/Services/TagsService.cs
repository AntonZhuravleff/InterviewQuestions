using TechQuestions.Application.Interfaces;
using TechQuestions.Application.Models;

namespace TechQuestions.Application.Services
{
    public class TagsService : ITagsService
    {
        public Task<IEnumerable<TagModel>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TagModel> GetById(int tagId)
        {
            throw new NotImplementedException();
        }

        public Task<TagModel> Create(TagModel tagModel)
        {
            throw new NotImplementedException();
        }

        public Task Delete(TagModel tagModel)
        {
            throw new NotImplementedException();
        }

        public Task Update(TagModel tagModel)
        {
            throw new NotImplementedException();
        }
    }
}
