using Ds.Base.Domain.Contexts.Abstractions;
using Ds.Base.Domain.Entities.Abstractions;
using Ds.Base.Domain.Repositories.Abstractions;

namespace Ds.Base.EntityFramework.Repositories;

public abstract class AuditableRepository<TAuditableEntity, TId>(IDatabaseContext databaseContext)
    : Repository<TAuditableEntity, TId>(databaseContext), IAuditableRepository
    where TAuditableEntity : class, IAuditableEntity<TId>, IEntity
    where TId : struct
{

}
