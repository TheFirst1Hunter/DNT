using System;
using DotNetTemplate.Data;
using DotNetTemplate.Data.Repository;
using DotNetTemplate.Core.Interfaces;
using DotNetTemplate.Presentation.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Core.Filters;
using AutoMapper;

public class TodoReadRepository : BaseReadRepository<Guid, Todo, TodoSingleDto, TodoListDto, TodoFilter>, ITodoReadRepository
{
    public TodoReadRepository(DotNetTemplateDbContext context) : base(context)
    {
    }
}
