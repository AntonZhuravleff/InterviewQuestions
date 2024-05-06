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
            CreateMap<CategoryModel, CategoryViewModel>().ReverseMap();
            CreateMap<TagModel, TagViewModel>().ReverseMap();
        }
    }
}
