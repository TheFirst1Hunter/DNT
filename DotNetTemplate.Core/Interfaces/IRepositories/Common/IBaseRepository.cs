using System;
using DotNetTemplate.Api.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Core.Filters;

namespace DotNetTemplate.Core.Interfaces.IRepositories;

public interface IBaseRepository<TKey, TEntity, TEntitySingleResponse, TEntityListResponse, TQueryFilter, TCreateDto, TUpdateDto>
where TEntity : BaseEntity<TKey>, new()
where TQueryFilter : BaseFilter, new()
where TEntityListResponse : BaseListDto<TKey>, new()
where TEntitySingleResponse : BaseSingleDto<TKey>, new()
where TCreateDto : BaseCreateDto, new()
where TUpdateDto : BaseUpdateDto, new()
{
    Task<TEntity> CreateAsync(TCreateDto createDto);
    Task<TEntity> UpdateAsync(TKey id, TUpdateDto updateDto);
    Task<List<TEntityListResponse>> ListAsync(TQueryFilter queryFilter);
    Task<TEntitySingleResponse> GetByIdAsync(TKey id);
    Task DeleteAsync(TKey id);
}