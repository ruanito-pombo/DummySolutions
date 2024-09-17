using System;
using Ds.Base.Domain.Entities.Abstractions;

namespace Ds.Base.EntityFramework.Entities;

public class AuditableEntity<TId> : IAuditableEntity<TId>, IEntity
    where TId : struct
{
    public TId Id { get; set; } = default;
    public DateTimeOffset CreateDate { get; set; } = DateTimeOffset.MinValue;
    public DateTimeOffset UpdateDate { get; set; } = DateTimeOffset.MinValue;
}

public class AuditableEntityInt : IAuditableEntity<int>, IEntity
{
    public int Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; } = DateTimeOffset.MinValue;
    public DateTimeOffset UpdateDate { get; set; } = DateTimeOffset.MinValue;
    public AuditableEntityInt() { }
    public AuditableEntityInt(int id) { Id = id; }
}

public class AuditableEntityLong : IAuditableEntity<long>, IEntity
{
    public long Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; } = DateTimeOffset.MinValue;
    public DateTimeOffset UpdateDate { get; set; } = DateTimeOffset.MinValue;
    public AuditableEntityLong() { }
    public AuditableEntityLong(long id) { Id = id; }
}

public class AuditableEntityShort : IAuditableEntity<short>, IEntity
{
    public short Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; } = DateTimeOffset.MinValue;
    public DateTimeOffset UpdateDate { get; set; } = DateTimeOffset.MinValue;
    public AuditableEntityShort() { }
    public AuditableEntityShort(short id) { Id = id; }
}
