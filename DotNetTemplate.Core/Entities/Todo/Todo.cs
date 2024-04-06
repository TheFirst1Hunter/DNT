using System;
namespace DotNetTemplate.Core.Entities;

public class Todo : BaseEntity<Guid>
{
    private string Title { set; get; }
    private string Content { set; get; }

    public Todo() { }

    public Todo(string title, string content)
    {
        this.Title = title;
        this.Content = content;
    }
}