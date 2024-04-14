using DotNetTemplate.Data.DTOs;
using DotNetTemplate.Presentation.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Presentation.Filters;
using DotNetTemplate.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = "All:Todo")]
public class TodoController : BaseController<Guid, Todo, TodoSingleDto, TodoListDto, TodoFilter, CreateTodoDto, UpdateTodoDto>
{
    public TodoController(ITodoWriteRepository writeRepository, ITodoReadRepository readRepository, IMapper mapper) : base(writeRepository, readRepository, mapper)
    {
    }
}