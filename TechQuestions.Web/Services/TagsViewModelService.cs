using AutoMapper;
using TechQuestions.Application.Interfaces;
using TechQuestions.Application.Models;
using TechQuestions.Web.Interfaces;
using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Services
{
    public class TagsViewModelService : ITagsViewModelService
    {
        private readonly ITagsService _tagsAppService;
        private readonly IMapper _mapper;

        public TagsViewModelService(ITagsService tagsAppService, IMapper mapper)
        {
            _tagsAppService = tagsAppService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TagViewModel>> GetAllTags()
        {
            var tags = await _tagsAppService.ListAsync();
            var mappedTags = _mapper.Map<IEnumerable<TagViewModel>>(tags);

            return mappedTags;
        }

        public async Task<TagsViewModel> GetTagsViewModel()
        {
            var tags = await GetAllTags();
            return new TagsViewModel { Tags = tags };
        }

        public async Task AddTag(TagViewModel tagViewModel)
        {
            var mappedTag = _mapper.Map<TagModel>(tagViewModel);

            await _tagsAppService.Create(mappedTag);
        }

        public async Task DeleteTag(int tagId)
        {
           await _tagsAppService.Delete(tagId);
        }
    }
}
