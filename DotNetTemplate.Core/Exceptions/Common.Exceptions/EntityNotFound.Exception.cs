namespace DotNetTemplate.Core.Exceptions;

public class EntityNotFoundException : BaseException
{
    public EntityNotFoundException(Guid entityId, string entity) : base($"{entity} of id {entityId} not found", 404, "not_found") { }
}