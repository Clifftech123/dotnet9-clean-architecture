using AutoMapper;
using Todo.Domain.Contracts;
using Todo.Domain.Entities;

namespace Todo.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoItem, TodoItemDto>()
                    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Title))
                    .ReverseMap();

            CreateMap<CreateTodoRequest, TodoItem>()
                .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdateDate, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());


            CreateMap<UpdateTodoRequest, TodoItem>()
               .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
             .ForMember(dest => dest.UpdateDate, opt => opt.Ignore())
             .ForMember(dest => dest.Id, opt => opt.Ignore())
             .ForMember(dest => dest.TodoCategoryId, opt => opt.Ignore())
             .ForMember(dest => dest.Category, opt => opt.Ignore());




            CreateMap<TodoCategory, TodoCategoryDto>().ReverseMap();

            CreateMap<CreateTodoCategoryRequest, TodoCategory>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UpdateTodoCategoryRequest, TodoCategory>();








        }
    }
}
