using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechQuestions.Application.Models;
using TechQuestions.Core.Entities;

namespace TechQuestions.Application.Mapper
{
    public class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<AspnetRunDtoMapper>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;

        public class AspnetRunDtoMapper : Profile
        {
            public AspnetRunDtoMapper()
            {
                CreateMap<Question, QuestionModel>().ReverseMap();
                CreateMap<Category, CategoryModel>().ReverseMap();
                CreateMap<Tag, TagModel>().ReverseMap();
            }
        }
    }
}
