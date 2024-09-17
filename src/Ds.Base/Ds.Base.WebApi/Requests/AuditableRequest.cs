using Ds.Base.Domain.WebApis.Requests.Abstractions;

namespace Ds.Base.WebApi.Requests;

public class AuditableRequest<TId> : IAuditableRequest<TId>, IRequest
    where TId : struct
{
    public TId Id { get; set; } = default;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
}

public class AuditableRequestInt : IAuditableRequest<int>, IRequest
{
    public int Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableRequestInt() { }
    public AuditableRequestInt(int id) { Id = id; }
}

public class AuditableRequestLong : IAuditableRequest<long>, IRequest
{
    public long Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableRequestLong() { }
    public AuditableRequestLong(long id) { Id = id; }
}

public class AuditableRequestShort : IAuditableRequest<short>, IRequest
{
    public short Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableRequestShort() { }
    public AuditableRequestShort(short id) { Id = id; }
}