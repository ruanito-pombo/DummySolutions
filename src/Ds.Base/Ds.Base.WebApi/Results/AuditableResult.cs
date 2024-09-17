using Ds.Base.Domain.WebApis.Results.Abstractions;

namespace Ds.Base.WebApi.Results;

public class AuditableResult<TId> : IAuditableResult<TId>, IResult
    where TId : struct
{
    public TId Id { get; set; } = default;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
}

public class AuditableResultInt : IAuditableResult<int>, IResult
{
    public int Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableResultInt() { }
    public AuditableResultInt(int id) { Id = id; }
}

public class AuditableResultLong : IAuditableResult<long>, IResult
{
    public long Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableResultLong() { }
    public AuditableResultLong(long id) { Id = id; }
}

public class AuditableResultShort : IAuditableResult<short>, IResult
{
    public short Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableResultShort() { }
    public AuditableResultShort(short id) { Id = id; }
}