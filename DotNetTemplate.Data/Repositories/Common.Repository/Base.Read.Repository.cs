using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using AutoMapper;
using DotNetTemplate.Data.DTOs;
using DotNetTemplate.Core.Entities;
using DotNetTemplate.Data.Interfaces;
using System.ComponentModel.DataAnnotations;
using DotNetTemplate.Core.Exceptions;

namespace DotNetTemplate.Data.Repository
{
    public class BaseReadRepository<TKey, TEntity, TEntitySingleResponse, TEntityListResponse, TQueryFilter> : IBaseReadRepository<TKey, TEntity, TEntitySingleResponse, TEntityListResponse, TQueryFilter>
      where TKey : IEquatable<TKey>
      where TEntity : BaseEntity<TKey>, new()
      where TQueryFilter : BaseQuery, new()
      where TEntityListResponse : BaseListDto<TKey>, new()
      where TEntitySingleResponse : BaseSingleDto<TKey>, new()

    {
        private readonly DotNetTemplateDbContext _context;

        public BaseReadRepository(DotNetTemplateDbContext context)
        {
            _context = context;
        }
        public virtual async Task<CountRepositoryWrapper<TKey, TEntityListResponse>> ListAsync(TQueryFilter queryFilter)
        {
            IQueryable<TEntityListResponse> entityQuery = _context
                                                              .Set<TEntity>()
                                                              .Select(e => new TEntityListResponse { Id = e.Id });

            List<TEntityListResponse> entities = await entityQuery.Skip(queryFilter.Skip)
                                                              .Take(queryFilter.Take)
                                                              .OrderByDescending(e => e.CreatedAt)
                                                              .AsNoTracking()
                                                              .ToListAsync();
            int count = await entityQuery.CountAsync();

            CountRepositoryWrapper<TKey, TEntityListResponse> countedEntities = new CountRepositoryWrapper<TKey, TEntityListResponse>(entities, count);

            return countedEntities;
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
                throw new EntityNotFoundException<TKey>(id, typeof(TEntity).Name);
            }

            return entity;
        }
    }
}
