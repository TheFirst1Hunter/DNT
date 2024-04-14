using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetTemplate.Presentation.DTOs;

public class UpdateTodoDto : UpdateBaseDto
{
    [Required]
    public string Title { set; get; }

    [Required]
    public string Content { set; get; }
}