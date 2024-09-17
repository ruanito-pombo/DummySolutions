using Ds.Base.Domain.WebApis.Results.Abstractions;

namespace Ds.Base.WebApi.Results;

public class IdentifiableResultEntity<TId> : IIdentifiableResult<TId>, IResult
    where TId : struct
{
    public TId Id { get; set; } = default;
}

public class IdentifiableResultInt : IIdentifiableResult<int>, IResult
{
    public int Id { get; set; } = 0;
    public IdentifiableResultInt() { }
    public IdentifiableResultInt(int id) { Id = id; }
}

public class IdentifiableResultLong : IIdentifiableResult<long>, IResult
{
    public long Id { get; set; } = 0;
    public IdentifiableResultLong() { }
    public IdentifiableResultLong(long id) { Id = id; }
}

public class IdentifiableResultShort : IIdentifiableResult<short>, IResult
{
    public short Id { get; set; } = 0;
    public IdentifiableResultShort() { }
    public IdentifiableResultShort(short id) { Id = id; }
}