using System;
using DotNetTemplate.Data.DTOs;
using DotNetTemplate.Core.Filters;
using DotNetTemplate.Core.Entities;

namespace DotNetTemplate.Core.Interfaces;

public interface IBaseReadRepository<TKey, TEntity, TEntitySingleResponse, TEntityListResponse, TQueryFilter>
where TEntity : BaseEntity<TKey>, new()
where TQueryFilter : BaseFilter, new()
where TEntityListResponse : BaseListDto<TKey>, new()
where TEntitySingleResponse : BaseSingleDto<TKey>, new()
{
    Task<List<TEntityListResponse>> ListAsync(TQueryFilter queryFilter);
    Task<TEntitySingleResponse> GetByIdAsync(TKey id);
}