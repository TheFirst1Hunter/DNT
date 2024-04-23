using System;

namespace DotNetTemplate.Core.Entities;

public interface IAuditedEntity<TKey>
{
    public TKey Id { get; set; }
}
