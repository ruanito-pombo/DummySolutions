using Ds.Base.Domain.Results.Abstractions;

namespace Ds.Base.WebApi.Results;

public class AuditableResult<TId> : Result, IResult, IAuditableResult<TId>
    where TId : struct
{
    public TId Id { get; set; } = default;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
}

public class AuditableResultInt : Result, IResult, IAuditableResult<int>
{
    public int Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableResultInt() { }
    public AuditableResultInt(int id) { Id = id; }
}

public class AuditableResultLong : Result, IResult, IAuditableResult<long>
{
    public long Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableResultLong() { }
    public AuditableResultLong(long id) { Id = id; }
}

public class AuditableResultShort : Result, IResult, IAuditableResult<short>
{
    public short Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableResultShort() { }
    public AuditableResultShort(short id) { Id = id; }
}