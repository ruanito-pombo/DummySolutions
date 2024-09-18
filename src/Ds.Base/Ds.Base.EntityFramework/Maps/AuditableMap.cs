using Ds.Base.Domain.Entities.Abstractions;
using Ds.Base.EntityFramework.Entities;
using Ds.Base.EntityFramework.Maps.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ds.Base.EntityFramework.Maps;

public abstract class AuditableMap<TAuditableEntity, TId> : IAuditableMap<TAuditableEntity, TId>
    where TAuditableEntity : class, IAuditableEntity<TId> where TId : struct
{
    protected virtual string TableName { get; set; } = string.Empty;

    public virtual void Configure(EntityTypeBuilder<TAuditableEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnOrder(1)
            .HasColumnType("BIGINT")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(e => e.CreateDate)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(e => e.UpdateDate)
            .HasColumnOrder(3)
            .IsRequired();
    }
}

public abstract class AuditableMapInt : AuditableMap<AuditableEntityInt, int>
{
    public override void Configure(EntityTypeBuilder<AuditableEntityInt> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnOrder(1);

        builder.Property(e => e.CreateDate)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(e => e.UpdateDate)
            .HasColumnOrder(3)
            .IsRequired();
    }
}

public abstract class AuditableMapLong : AuditableMap<AuditableEntityLong, long>
{
    public override void Configure(EntityTypeBuilder<AuditableEntityLong> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnOrder(1);

        builder.Property(e => e.CreateDate)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(e => e.UpdateDate)
            .HasColumnOrder(3)
            .IsRequired();
    }
}

public abstract class AuditableMapShort : AuditableMap<AuditableEntityShort, short>
{
    public override void Configure(EntityTypeBuilder<AuditableEntityShort> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnOrder(1);

        builder.Property(e => e.CreateDate)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(e => e.UpdateDate)
            .HasColumnOrder(3)
            .IsRequired();
    }
}