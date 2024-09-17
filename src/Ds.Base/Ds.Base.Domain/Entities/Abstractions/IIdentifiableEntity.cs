namespace Ds.Base.Domain.Entities.Abstractions;

public interface IIdentifiableEntity<TId> : IEntity
    where TId : struct
{

    TId Id { get; set; }

}
