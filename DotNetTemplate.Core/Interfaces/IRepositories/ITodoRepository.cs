using System;
using DotNetTemplate.Api.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Core.Filters;

namespace DotNetTemplate.Core.Interfaces.IRepositories;

public interface ITodoRepository : IBaseRepository<Guid, Todo, TodoSingleDto, TodoListDto, TodoFilter, CreateTodoDto, UpdateTodoDto> { }