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
}

public abstract class AuditableMapInt<TAuditableEntityInt> : AuditableMap<AuditableEntityInt, int>,
    IEntityTypeConfiguration<TAuditableEntityInt> where TAuditableEntityInt : class, IAuditableEntity<int>
{
    public virtual void Configure(EntityTypeBuilder<TAuditableEntityInt> builder, string tableName, string? comments = "")
    {
        TableName = tableName;
        builder.ToTable(name: TableName, action => action.HasComment(comments));

        builder.Property(e => e.Id)
            .HasColumnOrder(1)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasKey(e => e.Id)
            .HasName($"Pk{TableName}Id");

        builder.Property(e => e.CreateDate)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(e => e.UpdateDate)
            .HasColumnOrder(3)
            .IsRequired();
    }

    public virtual void Configure(EntityTypeBuilder<TAuditableEntityInt> builder)
    {
        builder.Property(e => e.Id)
            .HasColumnOrder(1)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasKey(e => e.Id)
            .HasName($"Pk{TableName}Id");

        builder.Property(e => e.CreateDate)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(e => e.UpdateDate)
            .HasColumnOrder(3)
            .IsRequired();
    }
}

public abstract class AuditableMapLong<TAuditableEntityLong> : AuditableMap<AuditableEntityLong, long>,
    IEntityTypeConfiguration<TAuditableEntityLong> where TAuditableEntityLong : class, IAuditableEntity<long>
{
    public virtual void Configure(EntityTypeBuilder<TAuditableEntityLong> builder, string tableName, string? comments = "")
    {
        TableName = tableName;
        builder.ToTable(name: TableName, action => action.HasComment(comments));

        builder.Property(e => e.Id)
            .HasColumnOrder(1)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasKey(e => e.Id)
            .HasName($"Pk{TableName}Id");

        builder.Property(e => e.CreateDate)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(e => e.UpdateDate)
            .HasColumnOrder(3)
            .IsRequired();
    }

    public virtual void Configure(EntityTypeBuilder<TAuditableEntityLong> builder)
    {
        builder.Property(e => e.Id)
            .HasColumnOrder(1)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasKey(e => e.Id)
            .HasName($"Pk{TableName}Id");

        builder.Property(e => e.CreateDate)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(e => e.UpdateDate)
            .HasColumnOrder(3)
            .IsRequired();
    }
}

public abstract class AuditableMapShort<TAuditableEntityShort> : AuditableMap<AuditableEntityShort, short>,
    IEntityTypeConfiguration<TAuditableEntityShort> where TAuditableEntityShort : class, IAuditableEntity<short>
{
    public virtual void Configure(EntityTypeBuilder<TAuditableEntityShort> builder, string tableName, string? comments = "")
    {
        TableName = tableName;
        builder.ToTable(name: TableName, action => action.HasComment(comments));

        builder.Property(e => e.Id)
            .HasColumnOrder(1)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasKey(e => e.Id)
            .HasName($"Pk{TableName}Id");

        builder.Property(e => e.CreateDate)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(e => e.UpdateDate)
            .HasColumnOrder(3)
            .IsRequired();
    }

    public virtual void Configure(EntityTypeBuilder<TAuditableEntityShort> builder)
    {
        builder.Property(e => e.Id)
            .HasColumnOrder(1)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasKey(e => e.Id)
            .HasName($"Pk{TableName}Id");

        builder.Property(e => e.CreateDate)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(e => e.UpdateDate)
            .HasColumnOrder(3)
            .IsRequired();
    }
}