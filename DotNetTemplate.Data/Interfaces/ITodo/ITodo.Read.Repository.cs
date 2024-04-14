using System;
using DotNetTemplate.Data.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Presentation.Filters;

namespace DotNetTemplate.Data.Interfaces;

public interface ITodoReadRepository : IBaseReadRepository<Guid, Todo, SingleTodoDto, ListTodoDto, TodoFilter> { }