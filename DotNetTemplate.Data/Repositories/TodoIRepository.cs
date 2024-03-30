using System;
using DotNetTemplate.Data;
using DotNetTemplate.Core.Interfaces.IRepositories;
using DotNetTemplate.Api.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Core.Filters;
using AutoMapper;

public class TodoRepository : BaseRepository<Guid, Todo, TodoSingleDto, TodoListDto, TodoFilter, CreateTodoDto, UpdateTodoDto>, ITodoRepository
{
    public TodoRepository(DotNetTemplateDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
