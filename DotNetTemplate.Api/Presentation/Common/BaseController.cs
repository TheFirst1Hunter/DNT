using DotNetTemplate.Api.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Core.Filters;
using DotNetTemplate.Core.Interfaces.IRepositories;
using Microsoft.AspNetCore.Mvc;

public class BaseController<TKey, TEntity, TEntitySingleResponse, TEntityListResponse, TQueryFilter, TCreateDto, TUpdateDto> : ControllerBase
where TEntity : BaseEntity<TKey>, new()
where TQueryFilter : BaseFilter, new()
where TEntityListResponse : BaseListDto<TKey>, new()
where TEntitySingleResponse : BaseSingleDto<TKey>, new()
where TCreateDto : BaseCreateDto, new()
where TUpdateDto : BaseUpdateDto, new()
    // where TRepository : IBaseRepository<TKey, TEntity, TEntitySingleResponse, TEntityListResponse, TQueryFilter, TCreateDto, TUpdateDto>
{
    private readonly IBaseRepository<TKey, TEntity, TEntitySingleResponse, TEntityListResponse, TQueryFilter, TCreateDto, TUpdateDto> _repository;

    public BaseController(IBaseRepository<TKey, TEntity, TEntitySingleResponse, TEntityListResponse, TQueryFilter, TCreateDto, TUpdateDto> repository)
    {
        _repository = repository;
    }

    [HttpGet("{id}")]
    public virtual async Task<ActionResult<TEntitySingleResponse>> GetByIdAsync(TKey id)
    {
        TEntitySingleResponse entity = await _repository.GetByIdAsync(id);
        if (entity == null)
        {
            return NotFound();
        }

        return Ok(entity); // You might want to return a specific response type
    }

    [HttpGet]
    public virtual async Task<ActionResult<TEntityListResponse>> GetAllAsync([FromQuery] TQueryFilter queryFilter)
    {
        var entities = await _repository.ListAsync(queryFilter);
        return Ok(entities); // You might want to return a specific response type for lists
    }

    [HttpPost]
    public virtual async Task<ActionResult<TEntity>> CreateAsync([FromBody] TCreateDto createDto)
    {
        var entity = await _repository.CreateAsync(createDto);

        return entity;
    }

    [HttpPut("{id}")]
    public virtual async Task<ActionResult<TEntity>> UpdateAsync([FromRoute] TKey id, [FromBody] TUpdateDto updateDto)
    {
        var entity = await _repository.UpdateAsync(id, updateDto);

        return entity;
    }

    [HttpDelete("{id}")]
    public virtual async Task DeleteAsync([FromRoute] TKey id)
    {
        await _repository.DeleteAsync(id);
    }
}
