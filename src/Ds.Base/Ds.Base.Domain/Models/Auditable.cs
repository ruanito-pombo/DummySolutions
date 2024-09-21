using Ds.Base.Domain.Models.Abstractions;

namespace Ds.Base.Domain.Models;

public class Auditable<TId> : Model, IModel, IAuditable<TId>
    where TId : struct
{
    public TId Id { get; set; } = default;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
}

public class AuditableInt : Model, IModel, IAuditable<int>
{
    public int Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableInt() { }
    public AuditableInt(int id) { Id = id; }
    public AuditableInt(int id, DateTimeOffset createDate, DateTimeOffset updateDate) { Id = id; CreateDate = createDate; UpdateDate = updateDate; }
}

public class AuditableLong : Model, IModel, IAuditable<long>
{
    public long Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableLong() { }
    public AuditableLong(long id) { Id = id; }
    public AuditableLong(long id, DateTimeOffset createDate, DateTimeOffset updateDate) { Id = id; CreateDate = createDate; UpdateDate = updateDate; }
}

public class AuditableShort : Model, IModel, IAuditable<short>
{
    public short Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableShort() { }
    public AuditableShort(short id) { Id = id; }
    public AuditableShort(short id, DateTimeOffset createDate, DateTimeOffset updateDate) { Id = id; CreateDate = createDate; UpdateDate = updateDate; }
}