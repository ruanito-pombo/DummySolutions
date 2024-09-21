using Ds.Base.Domain.Entities.Abstractions;

namespace Ds.Base.EntityFramework.Maps.Abstractions;

public interface IAuditableMap<TAuditableEntity, TId>
    where TAuditableEntity : class, IAuditableEntity<TId> where TId : struct
{



}