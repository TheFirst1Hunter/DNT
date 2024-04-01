using System;
namespace DotNetTemplate.Core.Entities;

public class BaseEntity<T>
{
    public T Id { set; get; }
    public DateTime CreatedAt { set; get; } = DateTime.UtcNow;

    public DateTime? DeletedAt { set; get; } = null;

    public DateTime? UpdatedAt { set; get; } = null;
}