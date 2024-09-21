using Ds.Base.Domain.Requests.Abstractions;

namespace Ds.Base.WebApi.Requests;

public class IdentifiableRequestEntity<TId> : Request, IRequest, IIdentifiableRequest<TId>
    where TId : struct
{
    public TId Id { get; set; } = default;
}

public class IdentifiableRequestInt : Request, IRequest, IIdentifiableRequest<int>
{
    public int Id { get; set; } = 0;
    public IdentifiableRequestInt() { }
    public IdentifiableRequestInt(int id) { Id = id; }
}

public class IdentifiableRequestLong : Request, IRequest, IIdentifiableRequest<long>
{
    public long Id { get; set; } = 0;
    public IdentifiableRequestLong() { }
    public IdentifiableRequestLong(long id) { Id = id; }
}

public class IdentifiableRequestShort : Request, IRequest, IIdentifiableRequest<short>
{
    public short Id { get; set; } = 0;
    public IdentifiableRequestShort() { }
    public IdentifiableRequestShort(short id) { Id = id; }
}