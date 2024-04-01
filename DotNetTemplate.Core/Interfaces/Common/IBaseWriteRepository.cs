using System;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Core.Filters;

namespace DotNetTemplate.Core.Interfaces;

public interface IBaseWriteRepository<TKey, TEntity>
where TEntity : BaseEntity<TKey>, new()
{
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TKey id, TEntity entity);
    Task DeleteAsync(TKey id);
}