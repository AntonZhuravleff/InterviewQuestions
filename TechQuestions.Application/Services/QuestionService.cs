using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechQuestions.Application.Interfaces;
using TechQuestions.Application.Mapper;
using TechQuestions.Application.Models;
using TechQuestions.Core.Entities;
using TechQuestions.Core.Interfaces.Repositories;
using TechQuestions.Core.Specifications;

namespace TechQuestions.Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly ITagsRepository _tagsRepository;

        public QuestionService(IQuestionRepository questionRepository, ITagsRepository tagsRepository)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository));
            _tagsRepository = tagsRepository ?? throw new ArgumentNullException(nameof(tagsRepository));
        }

        public async Task<IEnumerable<QuestionModel>> ListAsync(QuestionsFilterSpecification spec)
        {
            var questions = await _questionRepository.ListAsync(spec);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<QuestionModel>>(questions);
            return mapped;
        }

        public async Task<IEnumerable<QuestionModel>> ListAsync(QuestionsFilterPaginatedSpecification spec)
        {
            var questions = await _questionRepository.ListAsync(spec);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<QuestionModel>>(questions);
            return mapped;
        }

        public async Task<QuestionModel> GetById(int questionId)
        {
            var quesionWithCategoryAndTagsSpec = new QuestionByIdWithCategoryAndTagsSpecification(questionId);

            var question = await _questionRepository.GetBySpecAsync(quesionWithCategoryAndTagsSpec);
            var mapped = ObjectMapper.Mapper.Map<QuestionModel>(question);
            return mapped;
        }

        public async Task<QuestionModel> GetByIdWithTags(int questionId)
        {
            var quesionWithCategorySpec = new QuestionByIdWithTagsSpecification(questionId);

            var question = await _questionRepository.GetBySpecAsync(quesionWithCategorySpec);
            var mapped = ObjectMapper.Mapper.Map<QuestionModel>(question);
            return mapped;
        }

        public async Task SetTags(int questionId, IEnumerable<int> tagsIds)
        {
            var quesionWithCategorySpec = new QuestionByIdWithTagsSpecification(questionId);
            var question = await _questionRepository.GetBySpecAsync(quesionWithCategorySpec);

            var tags = await _tagsRepository.ListAsync(new TagsByIdsSpecification(tagsIds.ToList()));

            question.SetTags(tags);
            await _questionRepository.UpdateAsync(question);
        }

        public Task<int> CountAsync(QuestionsFilterSpecification spec)
        {
            return _questionRepository.CountAsync(spec);
        }

        public async Task<QuestionModel> Create(QuestionModel questionModel)
        {
            var mappedQuestion = ObjectMapper.Mapper.Map<Question>(questionModel);
            var newQuestion = await _questionRepository.AddAsync(mappedQuestion);

            var newQuestionMapped = ObjectMapper.Mapper.Map<QuestionModel>(newQuestion);
            return newQuestionMapped;
        }

        public async Task Update(QuestionModel questionModel)
        {
            var mappedQuestion = ObjectMapper.Mapper.Map<Question>(questionModel);
            await _questionRepository.UpdateAsync(mappedQuestion);
        }

        public async Task Delete(int questionId)
        {
            var questionToDelete = await _questionRepository.GetByIdAsync(questionId);
            await _questionRepository.DeleteAsync(questionToDelete);
        }
    }
}
