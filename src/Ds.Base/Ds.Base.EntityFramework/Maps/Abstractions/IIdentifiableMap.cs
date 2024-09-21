using Ds.Base.Domain.Entities.Abstractions;

namespace Ds.Base.EntityFramework.Maps.Abstractions;

public interface IIdentifiableMap<TIdentifiableEntity, TId>
    where TIdentifiableEntity : class, IIdentifiableEntity<TId> where TId : struct
{



}