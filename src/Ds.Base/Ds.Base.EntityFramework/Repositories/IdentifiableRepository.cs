using Ds.Base.Domain.Contexts.Abstractions;
using Ds.Base.Domain.Entities.Abstractions;
using Ds.Base.Domain.Repositories.Abstractions;
using Ds.Base.EntityFramework.Contexts;
using Ds.Base.EntityFramework.Extensions;

namespace Ds.Base.EntityFramework.Repositories;

public abstract class IdentifiableRepository<TDatabaseContext, TIdentifiableEntity, TId>(TDatabaseContext databaseContext)
    : Repository<TDatabaseContext, TIdentifiableEntity, TId>(databaseContext), IIdentifiableRepository
where TDatabaseContext : DatabaseContext
where TIdentifiableEntity : class, IIdentifiableEntity<TId>, IEntity
where TId : struct
{

    protected virtual async Task<TIdentifiableEntity?> GetEntity(TId id) => await Context.GetAsync<TIdentifiableEntity, TId>(id);

}