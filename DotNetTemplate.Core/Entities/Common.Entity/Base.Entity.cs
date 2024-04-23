using System;
namespace DotNetTemplate.Core.Entities;

public class BaseEntity<T>
{
    public T Id { set; get; }
    public bool IsDeleted { set; get; } = false;
    public DateTime CreatedAt { set; get; } = DateTime.UtcNow;
}
