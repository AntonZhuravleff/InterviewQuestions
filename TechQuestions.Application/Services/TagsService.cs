using TechQuestions.Application.Interfaces;
using TechQuestions.Application.Models;
using TechQuestions.Core.Interfaces.Repositories;
using TechQuestions.Application.Mapper;
using TechQuestions.Core.Entities;

namespace TechQuestions.Application.Services
{
    public class TagsService : ITagsService
    {
        private readonly ITagsRepository _tagsRepository;

        public TagsService(ITagsRepository tagsRepository)
        {
            _tagsRepository = tagsRepository ?? throw new ArgumentNullException(nameof(tagsRepository));
        }

        public async Task<IEnumerable<TagModel>> ListAsync()
        {
            var tags = await _tagsRepository.ListAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<TagModel>>(tags);
            return mapped;
        }

        public async Task<TagModel> GetById(int tagId)
        {
            var tag = await _tagsRepository.GetByIdAsync(tagId);
            var mapped = ObjectMapper.Mapper.Map<TagModel>(tag);
            return mapped;
        }

        public async Task<TagModel> Create(TagModel tagModel)
        {
            var mappedTag = ObjectMapper.Mapper.Map<Tag>(tagModel);
            var newTag = await _tagsRepository.AddAsync(mappedTag);

            var newTagMapped = ObjectMapper.Mapper.Map<TagModel>(newTag);
            return newTagMapped;
        }

        public async Task Update(TagModel tagModel)
        {
            var mappedQuestion = ObjectMapper.Mapper.Map<Tag>(tagModel);
            await _tagsRepository.UpdateAsync(mappedQuestion);
        }

        public async Task Delete(int tagId)
        {
            var tagToDelete = await _tagsRepository.GetByIdAsync(tagId);
            await _tagsRepository.DeleteAsync(tagToDelete);
        }
    }
}
