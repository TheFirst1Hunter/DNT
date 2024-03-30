using System;
namespace DotNetTemplate.Core.Entities;

public class Todo : BaseEntity<Guid>
{
    public string Title { set; get; }
    public string Content { set; get; }
}