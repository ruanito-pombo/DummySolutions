using Ds.Base.Domain.Results.Abstractions;

namespace Ds.Base.WebApi.Results;

public class IdentifiableResultEntity<TId> : Result, IResult, IIdentifiableResult<TId>
    where TId : struct
{
    public TId Id { get; set; } = default;
}

public class IdentifiableResultInt : Result, IResult, IIdentifiableResult<int>
{
    public int Id { get; set; } = 0;
    public IdentifiableResultInt() { }
    public IdentifiableResultInt(int id) { Id = id; }
}

public class IdentifiableResultLong : Result, IResult, IIdentifiableResult<long>
{
    public long Id { get; set; } = 0;
    public IdentifiableResultLong() { }
    public IdentifiableResultLong(long id) { Id = id; }
}

public class IdentifiableResultShort : Result, IResult, IIdentifiableResult<short>
{
    public short Id { get; set; } = 0;
    public IdentifiableResultShort() { }
    public IdentifiableResultShort(short id) { Id = id; }
}