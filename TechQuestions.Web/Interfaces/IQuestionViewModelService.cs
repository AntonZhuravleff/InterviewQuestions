﻿using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Interfaces
{
    public interface IQuestionViewModelService
    {
        public Task<QuestionsViewModel> GetQuestionsViewModel(int page, int questionsPerPage, int? categoryId, List<int>? tagIds);
    }
}