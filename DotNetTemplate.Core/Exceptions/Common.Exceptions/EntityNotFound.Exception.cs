namespace DotNetTemplate.Core.Exceptions;

public class EntityNotFoundException<TKey> : BaseException
{
    public EntityNotFoundException(TKey entityId, string entity) : base($"{entity} of id {entityId} not found", 404, "not_found") { }
}