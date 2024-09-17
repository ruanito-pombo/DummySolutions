namespace Ds.Base.Domain.Entities.Abstractions;

public interface IAuditableEntity<TId> : IEntity
    where TId : struct
{

    TId Id { get; set; }
    DateTimeOffset CreateDate { get; set; }
    DateTimeOffset UpdateDate { get; set; }

}
