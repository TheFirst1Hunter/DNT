using System;
using DotNetTemplate.Data;
using DotNetTemplate.Data.Repository;
using DotNetTemplate.Core.Interfaces;
using DotNetTemplate.Data.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Core.Filters;
using AutoMapper;

public class TodoWriteRepository : BaseWriteRepository<Guid, Todo>, ITodoWriteRepository
{
    public TodoWriteRepository(DotNetTemplateDbContext context) : base(context)
    {
    }
}
