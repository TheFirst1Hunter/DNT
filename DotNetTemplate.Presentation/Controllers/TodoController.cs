using DotNetTemplate.Presentation.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Core.Filters;
using DotNetTemplate.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

[Route("api/[controller]")]
[ApiController]
public class TodoController : BaseController<Guid, Todo, TodoSingleDto, TodoListDto, TodoFilter, CreateTodoDto, UpdateTodoDto>
{
    public TodoController(ITodoWriteRepository writeRepository, ITodoReadRepository readRepository, IMapper mapper) : base(writeRepository, readRepository, mapper)
    {
    }

}