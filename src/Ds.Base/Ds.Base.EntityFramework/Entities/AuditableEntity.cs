using Ds.Base.Domain.Entities.Abstractions;

namespace Ds.Base.EntityFramework.Entities;

public class AuditableEntity<TId> : Entity, IEntity, IAuditableEntity<TId>
    where TId : struct
{
    public TId Id { get; set; } = default;
    public DateTimeOffset CreateDate { get; set; } = DateTimeOffset.MinValue;
    public DateTimeOffset UpdateDate { get; set; } = DateTimeOffset.MinValue;
}

public class AuditableEntityInt : Entity, IEntity, IAuditableEntity<int>
{
    public int Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; } = DateTimeOffset.MinValue;
    public DateTimeOffset UpdateDate { get; set; } = DateTimeOffset.MinValue;
    public AuditableEntityInt() { }
    public AuditableEntityInt(int id) { Id = id; }
}

public class AuditableEntityLong : Entity, IEntity, IAuditableEntity<long>
{
    public long Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; } = DateTimeOffset.MinValue;
    public DateTimeOffset UpdateDate { get; set; } = DateTimeOffset.MinValue;
    public AuditableEntityLong() { }
    public AuditableEntityLong(long id) { Id = id; }
}

public class AuditableEntityShort : Entity, IEntity, IAuditableEntity<short>
{
    public short Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; } = DateTimeOffset.MinValue;
    public DateTimeOffset UpdateDate { get; set; } = DateTimeOffset.MinValue;
    public AuditableEntityShort() { }
    public AuditableEntityShort(short id) { Id = id; }
}
