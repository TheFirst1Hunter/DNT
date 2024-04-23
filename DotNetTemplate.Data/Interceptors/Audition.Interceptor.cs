using System;
using System.Threading;
using System.Threading.Tasks;
using DotNetTemplate.Application.Interfaces;
using DotNetTemplate.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;

namespace DotNetTemplate.Data.Interceptors;
public class AuditionInterceptor : SaveChangesInterceptor
{
    private readonly IUserService _userService;

    public AuditionInterceptor(IUserService userService)
    {
        _userService = userService;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var entries = eventData.Context.ChangeTracker.Entries<IAuditedEntity<Guid>>();
        foreach (var entry in entries)
        {
            var currentValuesJson = JsonConvert.SerializeObject(entry.CurrentValues.Properties.ToDictionary(kv => kv.Name, kv => entry?.CurrentValues?[kv]?.ToString()), Formatting.None,
   new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            var originalValuesJson = JsonConvert.SerializeObject(entry.OriginalValues.Properties.ToDictionary(kv => kv.Name, kv => entry?.OriginalValues?[kv]?.ToString()), Formatting.None,
new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            if (entry.State == EntityState.Added)
            {
                var userId = _userService.GetCurrentUserId();
                var userName = _userService.GetCurrentUserName();

                var audition = new AuditedEntity<Guid>(MutationTypes.Created, userId, userName, entry.Entity.Id.ToString(), null, currentValuesJson, entry.Entity.GetType().Name.ToString());

                // Save the audition record to the database
                eventData.Context.Set<AuditedEntity<Guid>>().Add(audition);
            }

            if (entry.State == EntityState.Modified)
            {
                var userId = _userService.GetCurrentUserId();
                var userName = _userService.GetCurrentUserName();

                var audition = new AuditedEntity<Guid>(MutationTypes.Updated, userId, userName, entry.Entity.Id.ToString(), originalValuesJson, currentValuesJson, entry.Entity.GetType().Name.ToString());

                // Save the audition record to the database
                eventData.Context.Set<AuditedEntity<Guid>>().Add(audition);
            }

            if (entry.State == EntityState.Deleted)
            {
                var userId = _userService.GetCurrentUserId();
                var userName = _userService.GetCurrentUserName();

                var audition = new AuditedEntity<Guid>(MutationTypes.Deleted, userId, userName, entry.Entity.Id.ToString(), originalValuesJson, null, entry.Entity.GetType().Name.ToString());

                // Save the audition record to the database
                eventData.Context.Set<AuditedEntity<Guid>>().Add(audition);
            }
        }

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var entries = eventData.Context.ChangeTracker.Entries<IAuditedEntity<Guid>>();
        foreach (var entry in entries.ToList())
        {
            if (entry.State == EntityState.Added)
            {
                var userId = _userService.GetCurrentUserId();
                var userName = _userService.GetCurrentUserName();

                var currentValuesJson = JsonConvert.SerializeObject(entry.CurrentValues.Properties.ToDictionary(kv => kv.Name, kv => entry.CurrentValues[kv].ToString()), Formatting.None,
    new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                //             var originalValuesJson = JsonConvert.SerializeObject(entry.OriginalValues.Properties.ToDictionary(kv => kv.Name, kv => entry.OriginalValues[kv].ToString()), Formatting.None,
                // new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

                var audition = new AuditedEntity<Guid>(MutationTypes.Created, userId, userName, entry.Entity.Id.ToString(), null, currentValuesJson, entry.Entity.GetType().Name.ToString());

                eventData.Context.Set<AuditedEntity<Guid>>().Add(audition);
            }

            if (entry.State == EntityState.Modified)
            {
                var userId = _userService.GetCurrentUserId();
                var userName = _userService.GetCurrentUserName();

                var currentValuesJson = JsonConvert.SerializeObject(entry.CurrentValues.Properties.ToDictionary(kv => kv.Name, kv => entry.CurrentValues[kv].ToString()), Formatting.None,
   new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                var originalValuesJson = JsonConvert.SerializeObject(entry.OriginalValues.Properties.ToDictionary(kv => kv.Name, kv => entry.OriginalValues[kv].ToString()), Formatting.None,
    new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

                var audition = new AuditedEntity<Guid>(MutationTypes.Updated, userId, userName, entry.Entity.Id.ToString(), originalValuesJson, currentValuesJson, entry.Entity.GetType().Name.ToString());

                eventData.Context.Set<AuditedEntity<Guid>>().Add(audition);
            }

            if (entry.State == EntityState.Deleted)
            {
                var userId = _userService.GetCurrentUserId();
                var userName = _userService.GetCurrentUserName();

                //                 var currentValuesJson = JsonConvert.SerializeObject(entry.CurrentValues.Properties.ToDictionary(kv => kv.Name, kv => entry.CurrentValues[kv].ToString()), Formatting.None,
                //    new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                var originalValuesJson = JsonConvert.SerializeObject(entry.OriginalValues.Properties.ToDictionary(kv => kv.Name, kv => entry.OriginalValues[kv].ToString()), Formatting.None,
    new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

                var audition = new AuditedEntity<Guid>(MutationTypes.Deleted, userId, userName, entry.Entity.Id.ToString(), originalValuesJson, null, entry.Entity.GetType().Name.ToString());

                eventData.Context.Set<AuditedEntity<Guid>>().Add(audition);
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

}