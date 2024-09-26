using Ds.Base.Domain.Entities.Abstractions;
using Ds.Base.Domain.Repositories.Abstractions;
using Ds.Base.EntityFramework.Contexts;
using Ds.Base.EntityFramework.Extensions;

namespace Ds.Base.EntityFramework.Repositories;

public abstract class AuditableRepository<TDatabaseContext, TAuditableEntity, TId>(TDatabaseContext databaseContext)
    : Repository<TDatabaseContext, TAuditableEntity, TId>(databaseContext), IAuditableRepository
where TDatabaseContext : DatabaseContext
where TAuditableEntity : class, IAuditableEntity<TId>, IEntity
where TId : struct
{
    protected virtual async Task<TAuditableEntity?> GetEntity(TId id) => await Context.GetAsync<TAuditableEntity, TId>(id);

}
