using AutoMapper;
using TechQuestions.Application.Interfaces;
using TechQuestions.Application.Models;
using TechQuestions.Core.Entities;
using TechQuestions.Web.Interfaces;
using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Services
{
    public class CategoryViewModelService : ICategoryViewModelService
    {
        private readonly ICategoryService _categoryAppService;
        private readonly IFileUploadService _fileUploadService;
        private readonly IMapper _mapper;

        public CategoryViewModelService(ICategoryService categoryAppService, IFileUploadService fileUploadService, IMapper mapper)
        {
            _categoryAppService = categoryAppService;
            _fileUploadService = fileUploadService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            var categories = await _categoryAppService.ListAsync();
            var mappedCategories = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);

            return mappedCategories;
        }

        public async Task<CategoriesViewModel> GetCategoriesViewModel()
        {
            return new CategoriesViewModel { Categories = await GetAllCategories() };
        }

        public async Task<CategoryViewModel> GetCategoryById(int id)
        {
            var category = await _categoryAppService.GetById(id);
            var mappedCategory = _mapper.Map<CategoryViewModel>(category);

            return mappedCategory;
        }

        public async Task AddCategory(CategoryAddViewModel categoryViewModel)
        {
            var uploadedFilePath = await _fileUploadService.UploadImageAsync(categoryViewModel.ImageFile, Constants.CATEGORY_IMAGES_PATH);

            var mappedCategory = _mapper.Map<CategoryModel>(new CategoryViewModel { Name = categoryViewModel.Name, ImageName = uploadedFilePath.Split(Constants.CATEGORY_IMAGES_PATH)[1],
                Color = categoryViewModel.Color });

            await _categoryAppService.Create(mappedCategory);
        }
    }
}
