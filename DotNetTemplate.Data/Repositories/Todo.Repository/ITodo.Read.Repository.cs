using System;
using DotNetTemplate.Data.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Presentation.DTOs;

namespace DotNetTemplate.Data.Interfaces;

public interface ITodoReadRepository : IBaseReadRepository<Guid, Todo, SingleTodoDto, ListTodoDto, TodoQuery> { }