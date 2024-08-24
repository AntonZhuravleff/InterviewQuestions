using AutoMapper;
using TechQuestions.Application.Models;
using TechQuestions.Web.ViewModels;

namespace TechQuestions.Web.Mapper
{
    public class WebProfile : Profile
    {
        public WebProfile() 
        { 
            CreateMap<QuestionModel, QuestionViewModel> ().ReverseMap();
            CreateMap<QuestionModel, QuestionPreviewViewModel>().ReverseMap();
            CreateMap<CategoryModel, CategoryViewModel>().ReverseMap();
            CreateMap<TagModel, TagViewModel>().ReverseMap();
            CreateMap<TestModel, TestCreateViewModel>()
                .ForMember(x => x.Id, m => m.MapFrom(a => a.Id))
                .ForMember(x => x.Name, m => m.MapFrom(a => a.Name)).ReverseMap();
            CreateMap<TestModel, TestPreviewViewModel>().ReverseMap();
            CreateMap<TestModel, TestViewModel>().ReverseMap();
        }
    }
}
