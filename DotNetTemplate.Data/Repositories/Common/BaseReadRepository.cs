using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using AutoMapper;
using DotNetTemplate.Data.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Core.Filters;
using DotNetTemplate.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DotNetTemplate.Data.Repository
{
    public class BaseReadRepository<TKey, TEntity, TEntitySingleResponse, TEntityListResponse, TQueryFilter> : IBaseReadRepository<TKey, TEntity, TEntitySingleResponse, TEntityListResponse, TQueryFilter>
      where TKey : IEquatable<TKey>
      where TEntity : BaseEntity<TKey>, new()
      where TQueryFilter : BaseFilter, new()
      where TEntityListResponse : BaseListDto<TKey>, new()
      where TEntitySingleResponse : BaseSingleDto<TKey>, new()

    {
        private readonly DotNetTemplateDbContext _context;

        public BaseReadRepository(DotNetTemplateDbContext context)
        {
            _context = context;
        }
        public virtual async Task<List<TEntityListResponse>> ListAsync(TQueryFilter queryFilter)
        {
            List<TEntityListResponse> entities = await _context
                                                              .Set<TEntity>()
                                                              .Select(e => new TEntityListResponse { Id = e.Id })
                                                              .Skip(queryFilter.Skip)
                                                              .Take(queryFilter.Take)
                                                              .AsNoTracking()
                                                              .ToListAsync();
            return entities;
        }

        public virtual async Task<TEntitySingleResponse> GetByIdAsync(TKey id)
        {
            TEntitySingleResponse? entity = await _context
                                                         .Set<TEntity>()
                                                         .Select(e => new TEntitySingleResponse { Id = e.Id })
                                                         .AsNoTracking()
                                                         .FirstOrDefaultAsync(e => e.Id.ToString() == id.ToString());
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with ID '{id}' not found.");
            }

            return entity;
        }
    }
}
