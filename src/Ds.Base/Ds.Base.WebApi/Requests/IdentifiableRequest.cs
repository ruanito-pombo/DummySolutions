using Ds.Base.Domain.WebApis.Requests.Abstractions;

namespace Ds.Base.WebApi.Requests;

public class IdentifiableRequestEntity<TId> : IIdentifiableRequest<TId>, IRequest
    where TId : struct
{
    public TId Id { get; set; } = default;
}

public class IdentifiableRequestInt : IIdentifiableRequest<int>, IRequest
{
    public int Id { get; set; } = 0;
    public IdentifiableRequestInt() { }
    public IdentifiableRequestInt(int id) { Id = id; }
}

public class IdentifiableRequestLong : IIdentifiableRequest<long>, IRequest
{
    public long Id { get; set; } = 0;
    public IdentifiableRequestLong() { }
    public IdentifiableRequestLong(long id) { Id = id; }
}

public class IdentifiableRequestShort : IIdentifiableRequest<short>, IRequest
{
    public short Id { get; set; } = 0;
    public IdentifiableRequestShort() { }
    public IdentifiableRequestShort(short id) { Id = id; }
}