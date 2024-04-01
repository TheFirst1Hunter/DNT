using AutoMapper;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Presentation.DTOs;

namespace DotNetTemplate.Mapper;

public class AnswerProfile : Profile
{
    public AnswerProfile()
    {
        CreateMap<CreateTodoDto, Todo>();
    }
}