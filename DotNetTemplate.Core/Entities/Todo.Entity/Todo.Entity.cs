using System;
namespace DotNetTemplate.Core.Entities;

public class Todo : BaseEntity<Guid>, IAuditedEntity<Guid>
{
    public string Title { set; get; }
    public string Content { set; get; }

    public Todo() { }

    public Todo(string title, string content)
    {
        this.Title = title;
        this.Content = content;
    }
}