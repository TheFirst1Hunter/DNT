using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetTemplate.Api.DTOs;

public class CreateTodoDto : BaseCreateDto
{
    [Required]
    public string Title { set; get; }

    [Required]
    public string Content { set; get; }
}