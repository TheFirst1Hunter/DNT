using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using AutoMapper;
using DotNetTemplate.Api.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Core.Filters;
using DotNetTemplate.Data;
using System.ComponentModel.DataAnnotations;

namespace DotNetTemplate.Core.Interfaces.IRepositories
{
    public class BaseRepository<TKey, TEntity, TEntitySingleResponse, TEntityListResponse, TQueryFilter, TCreateDto, TUpdateDto> : IBaseRepository<TKey, TEntity, TEntitySingleResponse, TEntityListResponse, TQueryFilter, TCreateDto, TUpdateDto>
      where TKey : IEquatable<TKey>
      where TEntity : BaseEntity<TKey>, new()
      where TQueryFilter : BaseFilter, new()
      where TEntityListResponse : BaseListDto<TKey>, new()
      where TEntitySingleResponse : BaseSingleDto<TKey>, new()
      where TCreateDto : BaseCreateDto, new()
      where TUpdateDto : BaseUpdateDto, new()
    {
        private readonly DotNetTemplateDbContext _context;
        private readonly IMapper _mapper;

        public BaseRepository(DotNetTemplateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual async Task<TEntity> CreateAsync(TCreateDto createDto)
        {
            TEntity entity = _mapper.Map<TEntity>(createDto);
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync(); // Save changes after adding the entity
            return entity; // Return the created entity
        }

        public virtual async Task<TEntity> UpdateAsync(TKey id, TUpdateDto updateDto)
        {

            TEntity? existing = await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id.ToString() == id.ToString());

            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity with ID '{id}' not found.");
            }

            // Get key properties for both instances
            var existingKeys = existing.GetType().GetProperties().ToList();
            var updateDtoKeys = updateDto.GetType().GetProperties().ToList();

            // Compare and replace matching keys
            foreach (var keyProperty in existingKeys)
            {
                var updateDtoValue = updateDtoKeys.SingleOrDefault(p => p.Name == keyProperty.Name)?.GetValue(updateDto);
                if (updateDtoValue != null)
                {
                    var existingValue = keyProperty.GetValue(existing);
                    if (!EqualityComparer<object>.Default.Equals(existingValue, updateDtoValue))
                    {
                        keyProperty.SetValue(existing, updateDtoValue);
                        _context.Entry(existing).State = EntityState.Modified;
                    }
                }
            }

            await _context.SaveChangesAsync();

            return existing;
        }

        public virtual async Task<List<TEntityListResponse>> ListAsync(TQueryFilter queryFilter)
        {
            // Implement logic to filter entities based on queryFilter
            // You can use LINQ expressions or other filtering techniques
            List<TEntityListResponse> entities = await _context.Set<TEntity>().Select(e => new TEntityListResponse { Id = e.Id }).Skip(queryFilter.Skip).Take(queryFilter.Take).ToListAsync(); // Start with all entities
            return entities;
        }

        public virtual async Task<TEntitySingleResponse> GetByIdAsync(TKey id)
        {
            TEntitySingleResponse? entity = await _context.Set<TEntity>().Select(e => new TEntitySingleResponse { Id = e.Id }).FirstOrDefaultAsync(e => e.Id.ToString() == id.ToString());

            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with ID '{id}' not found.");
            }

            return entity;
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            TEntity? entity = await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id.ToString() == id.ToString());
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with ID '{id}' not found.");
            }

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
