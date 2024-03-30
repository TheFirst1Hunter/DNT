using DotNetTemplate.Api.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Core.Filters;
using DotNetTemplate.Core.Interfaces.IRepositories;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TodoController : BaseController<Guid, Todo, TodoSingleDto, TodoListDto, TodoFilter, CreateTodoDto, UpdateTodoDto>
{
    public TodoController(ITodoRepository repository) : base(repository)
    {
    }

}