using Ds.Base.Domain.Requests.Abstractions;

namespace Ds.Base.WebApi.Requests;

public class AuditableRequest<TId> : Request, IRequest, IAuditableRequest<TId>
    where TId : struct
{
    public TId Id { get; set; } = default;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
}

public class AuditableRequestInt : Request, IRequest, IAuditableRequest<int>
{
    public int Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableRequestInt() { }
    public AuditableRequestInt(int id) { Id = id; }
}

public class AuditableRequestLong : Request, IRequest, IAuditableRequest<long>
{
    public long Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableRequestLong() { }
    public AuditableRequestLong(long id) { Id = id; }
}

public class AuditableRequestShort : Request, IRequest, IAuditableRequest<short>
{
    public short Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableRequestShort() { }
    public AuditableRequestShort(short id) { Id = id; }
}