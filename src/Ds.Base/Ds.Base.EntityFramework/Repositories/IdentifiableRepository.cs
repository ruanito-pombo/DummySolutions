using Ds.Base.Domain.Contexts.Abstractions;
using Ds.Base.Domain.Entities.Abstractions;
using Ds.Base.Domain.Repositories.Abstractions;

namespace Ds.Base.EntityFramework.Repositories;

public abstract class IdentifiableRepository<TIdentifiableEntity, TId>(IDatabaseContext databaseContext)
        : Repository<TIdentifiableEntity, TId>(databaseContext), IIdentifiableRepository
    where TIdentifiableEntity : IIdentifiableEntity<TId>
    where TId : struct
{

}
