using Ds.Base.Domain.Entities.Abstractions;
using Ds.Base.EntityFramework.Entities;
using Ds.Base.EntityFramework.Maps.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ds.Base.EntityFramework.Maps;

public abstract class IdentifiableMap<TIdentifiableEntity, TId> : IIdentifiableMap<TIdentifiableEntity, TId>
    where TIdentifiableEntity : class, IIdentifiableEntity<TId> where TId : struct
{
    protected virtual string TableName { get; set; } = string.Empty;

    public virtual void Configure(EntityTypeBuilder<TIdentifiableEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnOrder(1)
            .HasColumnType("BIGINT")
            .ValueGeneratedOnAdd()
            .IsRequired();
    }
}

public abstract class IdentifiableMapInt<TIdentifiableEntity> : IdentifiableMap<IdentifiableEntityInt, int>
{
    public override void Configure(EntityTypeBuilder<IdentifiableEntityInt> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnOrder(1);
    }
}

public abstract class IdentifiableMapLong : IdentifiableMap<IdentifiableEntityLong, long>
{
    public override void Configure(EntityTypeBuilder<IdentifiableEntityLong> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnOrder(1);
    }
}

public abstract class IdentifiableMapShort : IdentifiableMap<IdentifiableEntityShort, short>
{
    public override void Configure(EntityTypeBuilder<IdentifiableEntityShort> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnOrder(1);
    }
}