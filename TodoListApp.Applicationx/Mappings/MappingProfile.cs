using AutoMapper;
using TodoListApp.Domain.Entities;
using TodoListApp.Domain.Models;

namespace TodoListApp.Applicationx.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Category,CategoryModel>()
            //   // .ForMember(dest => dest.Name, opt=> opt.MapFrom(src=> src.Name))
                .ReverseMap();
        }
    }
}
