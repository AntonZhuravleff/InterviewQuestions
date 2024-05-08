﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechQuestions.Application.Models;
using TechQuestions.Core.Entities;
using TechQuestions.Core.Specifications;

namespace TechQuestions.Application.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionModel>> ListAsync(QuestionsFilterPaginatedSpecification spec);
        Task<QuestionModel> GetById(int questionId);
        Task<QuestionModel> Create(QuestionModel questionModel);
        Task Update(QuestionModel questionModel);
        Task Delete(QuestionModel questionModel);
    }
}
