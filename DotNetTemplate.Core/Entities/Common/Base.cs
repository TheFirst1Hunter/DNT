using System;
namespace DotNetTemplate.Core.Entities;

public class BaseEntity<T>
{
    public T Id { set; get; }
    public DateTime CreatedAt = DateTime.Now;

    public DateTime? DeletedAt { set; get; } = null;

    public DateTime? UpdatedAt { set; get; } = null;
}