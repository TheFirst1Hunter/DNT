using AutoMapper;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Presentation.DTOs;
using DotNetTemplate.Data.DTOs;

namespace DotNetTemplate.Presentation.Mapper;

public class TodoProfile : Profile
{
    public TodoProfile()
    {
        CreateMap<CreateTodoDto, Todo>();
        CreateMap<UpdateTodoDto, Todo>();
        CreateMap<TodoQueryDto, TodoQuery>();
    }
}