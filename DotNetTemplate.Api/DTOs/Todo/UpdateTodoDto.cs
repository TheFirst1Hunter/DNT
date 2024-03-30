using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetTemplate.Api.DTOs;

public class UpdateTodoDto : BaseUpdateDto
{
    [Required]
    public string Title { set; get; }

    [Required]
    public string Content { set; get; }
}