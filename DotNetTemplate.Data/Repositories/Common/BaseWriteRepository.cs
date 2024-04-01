using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using AutoMapper;
using DotNetTemplate.Presentation.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Core.Filters;
using DotNetTemplate.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DotNetTemplate.Data.Repository
{
    public class BaseWriteRepository<TKey, TEntity> : IBaseWriteRepository<TKey, TEntity>
      where TKey : IEquatable<TKey>
      where TEntity : BaseEntity<TKey>, new()
    {
        private readonly DotNetTemplateDbContext _context;

        public BaseWriteRepository(DotNetTemplateDbContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync(); // Save changes after adding the entity
            return entity; // Return the created entity
        }

        public virtual async Task<TEntity> UpdateAsync(TKey id, TEntity entity)
        {

            TEntity? existing = await _context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id.ToString() == id.ToString());

            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity with ID '{id}' not found.");
            }

            // Get key properties for both instances
            var existingKeys = existing.GetType().GetProperties().ToList();
            var updateDtoKeys = entity.GetType().GetProperties().ToList();

            // Compare and replace matching keys
            foreach (var keyProperty in existingKeys)
            {
                var updateDtoValue = updateDtoKeys.SingleOrDefault(p => p.Name == keyProperty.Name)?.GetValue(entity);
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
