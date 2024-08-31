using AutoMapper;
using TechQuestions.Application.Interfaces;
using TechQuestions.Core.Specifications;
using TechQuestions.Web.Interfaces;
using TechQuestions.Web.ViewModels;
using TechQuestions.Application.Models;

namespace TechQuestions.Web.Services
{
    public class TestViewModelService : ITestViewModelService
    {
        private readonly ITestService _testAppService;

        private readonly IMapper _mapper;

        public TestViewModelService(ITestService testAppService, IMapper mapper)
        {
            _testAppService = testAppService;
            _mapper = mapper;
        }


       public async Task AddTest(TestCreateViewModel testCreateViewMode)
        {
            var mappedTest = _mapper.Map<TestModel>(testCreateViewMode);

            await _testAppService.Create(mappedTest);
        }

        public async Task<TestsViewModel> GetTestsViewModel(int page, int testsPerPage)
        {
            var filterPaginatedSpecification = new TestPaginatedSpecification(page * testsPerPage, testsPerPage);

            var tests = await _testAppService.ListAsync(filterPaginatedSpecification);
            var totalCount = await _testAppService.CountAsync();

            var mappedTests = _mapper.Map<IEnumerable<TestPreviewViewModel>>(tests);

            var testsVM = new TestsViewModel()
            {
                Tests = mappedTests,
                PaginationInfo = new PaginationInfoViewModel()
                {
                    ActualPage = page,
                    ItemsPerPage = tests.Count(),
                    TotalItems = totalCount,
                    TotalPages = int.Parse(Math.Ceiling(((decimal)totalCount / testsPerPage)).ToString()),
                }
            };

            testsVM.PaginationInfo.Next = (testsVM.PaginationInfo.ActualPage == testsVM.PaginationInfo.TotalPages - 1) ?
                "page-container__link_disabled" : "page-container__link-next";

            testsVM.PaginationInfo.Previous = (testsVM.PaginationInfo.ActualPage == 0) ?
                "page-container__link_disabled" : "page-container__link-previous";

            return testsVM;
        }

        public async Task<TestViewModel> GetById(int testId)
        {
            var test = await _testAppService.GetById(testId);

            var mappedTest = _mapper.Map<TestViewModel>(test);
            return mappedTest;
        }

        public async Task AddQuestionToTest(TestQuestionViewModel testQuestion)
        {
            await _testAppService.AddQuestion(testQuestion.TestId, testQuestion.QuestionId);
        }
    }
}