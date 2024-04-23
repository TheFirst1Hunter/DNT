using System;

namespace DotNetTemplate.Core.Entities;

public class AuditedEntity<TKey>
{
    public TKey Id { get; set; }
    public string MutationType { get; set; } = MutationTypes.Created;
    public DateTime MutationDate { get; set; } = DateTime.UtcNow;
    public string? MutationById { get; set; }
    public string? MutationByName { get; set; }
    public string EntityId { get; set; }
    public string? OriginalEntity { get; set; }
    public string? MutatedEntity { get; set; }
    public string EntityType { get; set; }


    public AuditedEntity()
    {
    }

    public AuditedEntity(string mutationType, string mutationById, string mutationByName, string entityId, string originalEntity, string mutatedEntity, string entityType)
    {
        MutationType = mutationType;
        MutationById = mutationById;
        MutationByName = mutationByName;
        EntityId = entityId;
        OriginalEntity = originalEntity;
        MutatedEntity = mutatedEntity;
        EntityType = entityType;
    }
}
