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

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository ?? throw new ArgumentNullException(nameof(questionRepository)); ;
        }

        public async Task<IEnumerable<QuestionModel>> ListAsync(QuestionsFilterPaginatedSpecification spec)
        {
            var questions = await _questionRepository.ListAsync(spec);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<QuestionModel>>(questions);
            return mapped;
        }

        public async Task<QuestionModel> GetById(int questionId)
        {
            var question = await _questionRepository.GetByIdAsync(questionId);
            var mapped = ObjectMapper.Mapper.Map<QuestionModel>(question);
            return mapped;
        }

        public Task<QuestionModel> Create(QuestionModel questionModel)
        {
            throw new NotImplementedException();
        }

        public Task Delete(QuestionModel questionModel)
        {
            throw new NotImplementedException();
        }

        public Task Update(QuestionModel questionModel)
        {
            throw new NotImplementedException();
        }
    }
}
