using System;
using DotNetTemplate.Data;
using DotNetTemplate.Data.Repository;
using DotNetTemplate.Data.Interfaces;
using DotNetTemplate.Data.DTOs;
using DotNetTemplate.Core.Entities;
using AutoMapper;

public class TodoReadRepository : BaseReadRepository<Guid, Todo, SingleTodoDto, ListTodoDto, TodoQuery>, ITodoReadRepository
{
    public TodoReadRepository(DotNetTemplateDbContext context) : base(context)
    {
    }
}
