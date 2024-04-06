using AutoMapper;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Presentation.DTOs;

namespace DotNetTemplate.Presentation.Mapper;

public class AnswerProfile : Profile
{
    public AnswerProfile()
    {
        CreateMap<CreateTodoDto, Todo>();
    }
}