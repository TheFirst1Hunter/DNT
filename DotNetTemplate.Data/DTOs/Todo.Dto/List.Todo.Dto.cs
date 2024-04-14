using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetTemplate.Data.DTOs;

public class ListTodoDto : BaseListDto<Guid>
{
    public string Title { set; get; }

    public string Content { set; get; }
}