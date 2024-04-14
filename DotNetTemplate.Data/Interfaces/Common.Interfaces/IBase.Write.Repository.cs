using System;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Presentation.Filters;

namespace DotNetTemplate.Data.Interfaces;

public interface IBaseWriteRepository<TKey, TEntity>
where TEntity : BaseEntity<TKey>, new()
{
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TKey id, TEntity entity);
    Task DeleteAsync(TKey id);
}