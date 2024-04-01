using System;
using DotNetTemplate.Presentation.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Core.Filters;

namespace DotNetTemplate.Core.Interfaces;

public interface ITodoReadRepository : IBaseReadRepository<Guid, Todo, TodoSingleDto, TodoListDto, TodoFilter> { }