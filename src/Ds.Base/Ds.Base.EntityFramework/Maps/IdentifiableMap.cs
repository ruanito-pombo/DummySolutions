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
}

public abstract class IdentifiableMapInt<TIdentifiableEntityInt> : IdentifiableMap<IdentifiableEntityInt, int>,
    IEntityTypeConfiguration<TIdentifiableEntityInt> where TIdentifiableEntityInt : class, IIdentifiableEntity<int>
{
    public virtual void Configure(EntityTypeBuilder<TIdentifiableEntityInt> builder, string tableName, string? comments = "")
    {
        TableName = tableName;
        builder.ToTable(name: TableName, action => action.HasComment(comments));

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnOrder(1);
    }

    public virtual void Configure(EntityTypeBuilder<TIdentifiableEntityInt> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnOrder(1);
    }
}

public abstract class IdentifiableMapLong<TIdentifiableEntityLong> : IdentifiableMap<IdentifiableEntityLong, long>,
    IEntityTypeConfiguration<TIdentifiableEntityLong> where TIdentifiableEntityLong : class, IIdentifiableEntity<long>
{
    public virtual void Configure(EntityTypeBuilder<TIdentifiableEntityLong> builder, string tableName, string? comments = "")
    {
        TableName = tableName;
        builder.ToTable(name: TableName, action => action.HasComment(comments));

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnOrder(1);
    }

    public virtual void Configure(EntityTypeBuilder<TIdentifiableEntityLong> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnOrder(1);
    }
}

public abstract class IdentifiableMapShort<TIdentifiableEntityShort> : IdentifiableMap<IdentifiableEntityShort, short>,
    IEntityTypeConfiguration<TIdentifiableEntityShort> where TIdentifiableEntityShort : class, IIdentifiableEntity<short>
{
    public virtual void Configure(EntityTypeBuilder<TIdentifiableEntityShort> builder, string tableName, string? comments = "")
    {
        TableName = tableName;
        builder.ToTable(name: TableName, action => action.HasComment(comments));

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnOrder(1);
    }

    public virtual void Configure(EntityTypeBuilder<TIdentifiableEntityShort> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnOrder(1);
    }
}