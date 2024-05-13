using AutoMapper;
using TechQuestions.Application.Interfaces;
using TechQuestions.Web.Interfaces;
using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Services
{
    public class CategoryViewModelService : ICategoryViewModelService
    {
        private readonly ICategoryService _categoryAppService;
        private readonly IMapper _mapper;

        public CategoryViewModelService(ICategoryService categoryAppService, IMapper mapper)
        {
            _categoryAppService = categoryAppService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            var categories = await _categoryAppService.ListAsync();
            var mappedCategories = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);

            return mappedCategories;
        }
    }
}
