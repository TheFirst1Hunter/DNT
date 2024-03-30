using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetTemplate.Api.DTOs;

public class TodoListDto : BaseListDto<Guid>
{
    public string Title { set; get; }

    public string Content { set; get; }
}