using Ds.Base.Domain.Models.Abstractions;

namespace Ds.Base.Domain.Models;

public class Auditable<TId> : IAuditable<TId>, IModel
    where TId : struct
{
    public TId Id { get; set; } = default;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
}

public class AuditableInt : IAuditable<int>, IModel
{
    public int Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableInt() { }
    public AuditableInt(int id) { Id = id; }
}

public class AuditableLong : IAuditable<long>, IModel
{
    public long Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableLong() { }
    public AuditableLong(long id) { Id = id; }
}

public class AuditableShort : IAuditable<short>, IModel
{
    public short Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableShort() { }
    public AuditableShort(short id) { Id = id; }
}