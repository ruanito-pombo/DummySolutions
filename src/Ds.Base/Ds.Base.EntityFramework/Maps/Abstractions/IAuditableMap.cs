using Ds.Base.Domain.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Ds.Base.EntityFramework.Maps.Abstractions;

public interface IAuditableMap<TAuditableEntity, TId> : IEntityTypeConfiguration<TAuditableEntity>
    where TAuditableEntity : class, IAuditableEntity<TId> where TId : struct
{



}