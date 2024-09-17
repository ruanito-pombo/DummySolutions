using Ds.Base.Domain.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Ds.Base.EntityFramework.Maps.Abstractions;

public interface IIdentifiableMap<TIdentifiableEntity, TId> : IEntityTypeConfiguration<TIdentifiableEntity>
    where TIdentifiableEntity : class, IIdentifiableEntity<TId> where TId : struct
{



}