using DotNetTemplate.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DotNetTemplate.Data.Interceptors;

public class SoftDeleteInterceptor<TKey> : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Deleted && entry.Entity is BaseEntity<TKey> entity)
            {
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }

        return base.SavingChanges(eventData, result);
    }
}