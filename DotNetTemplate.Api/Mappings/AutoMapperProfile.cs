using AutoMapper;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Api.DTOs;

namespace DotNetTemplate.Mapper;

public class AnswerProfile : Profile
{
    public AnswerProfile()
    {
        CreateMap<CreateTodoDto, Todo>();
    }
}