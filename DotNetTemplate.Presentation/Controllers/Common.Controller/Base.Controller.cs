using DotNetTemplate.Data.DTOs;
using DotNetTemplate.Presentation.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Presentation.Filters;
using DotNetTemplate.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

public class BaseController<TKey, TEntity, TEntitySingleResponse, TEntityListResponse, TQueryFilter, TCreateDto, TUpdateDto> : ControllerBase
where TEntity : BaseEntity<TKey>, new()
where TQueryFilter : BaseFilter, new()
where TEntityListResponse : BaseListDto<TKey>, new()
where TEntitySingleResponse : BaseSingleDto<TKey>, new()
where TCreateDto : CreateBaseDto, new()
where TUpdateDto : UpdateBaseDto, new()
    // where TRepository : IBaseRepository<TKey, TEntity, TEntitySingleResponse, TEntityListResponse, TQueryFilter, TCreateDto, TUpdateDto>
{
    private readonly IBaseReadRepository<TKey, TEntity, TEntitySingleResponse, TEntityListResponse, TQueryFilter> _readRepository;
    private readonly IBaseWriteRepository<TKey, TEntity> _writeRepository;
    private readonly IMapper _mapper;

    public BaseController(IBaseWriteRepository<TKey, TEntity> writeRepository,
                          IBaseReadRepository<TKey, TEntity, TEntitySingleResponse, TEntityListResponse, TQueryFilter> readRepository,
                          IMapper mapper)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public virtual async Task<ActionResult<SingleResponseWrapper<TKey, TEntitySingleResponse>>> GetByIdAsync(TKey id)
    {
        TEntitySingleResponse entity = await _readRepository.GetByIdAsync(id);

        if (entity == null)
        {
            return NotFound();
        }

        SingleResponseWrapper<TKey, TEntitySingleResponse> singleResponse = new SingleResponseWrapper<TKey, TEntitySingleResponse>(entity, "Ok", false);

        return Ok(singleResponse);
    }

    [HttpGet]
    public virtual async Task<ActionResult<PaginatedResponseWrapper<TKey, TEntityListResponse>>> GetAllAsync([FromQuery] TQueryFilter queryFilter)
    {
        var entities = await _readRepository.ListAsync(queryFilter);

        PaginatedResponseWrapper<TKey, TEntityListResponse> paginatedResponse = new PaginatedResponseWrapper<TKey, TEntityListResponse>(entities.Data, entities.Count, queryFilter.Skip, queryFilter.Take);

        return Ok(entities);
    }

    [HttpPost]
    public virtual async Task<ActionResult<TEntity>> CreateAsync([FromBody] TCreateDto createDto)
    {
        TEntity e = _mapper.Map<TEntity>(createDto);

        var entity = await _writeRepository.CreateAsync(e);

        return entity;
    }

    [HttpPut("{id}")]
    public virtual async Task<ActionResult<TEntity>> UpdateAsync([FromRoute] TKey id, [FromBody] TUpdateDto updateDto)
    {
        TEntity e = _mapper.Map<TEntity>(updateDto);

        var entity = await _writeRepository.UpdateAsync(id, e);

        return entity;
    }

    [HttpDelete("{id}")]
    public virtual async Task DeleteAsync([FromRoute] TKey id)
    {
        await _writeRepository.DeleteAsync(id);
    }
}
