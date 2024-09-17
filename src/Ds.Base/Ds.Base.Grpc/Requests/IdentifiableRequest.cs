using Ds.Base.Domain.Grpcs.Requests.Abstractions;
using Ds.Base.Grpc.Protos;

namespace Ds.Base.Grpc.Requests;

public class IdentifiableRequest<TId> : IIdentifiableRequest<TId>, IRequest
    where TId : struct
{
    public HeaderMessage Header { get; set; } = new() { Header = string.Empty };
    public ReturnMessage Return { get; set; } = new() { ErrorCode = 0, Message = string.Empty, Status = false };
    public TId Id { get; set; } = default;
}

public class IdentifiableRequestInt : IIdentifiableRequest<int>, IRequest
{
    public HeaderMessage Header { get; set; } = new() { Header = string.Empty };
    public ReturnMessage Return { get; set; } = new() { ErrorCode = 0, Message = string.Empty, Status = false };
    public int Id { get; set; } = 0;
    public IdentifiableRequestInt() { }
    public IdentifiableRequestInt(int id) { Id = id; }
    public IdentifiableMessageInt MapTo() => new()
    {
        Header = Header,
        Return = Return,
        Id = Id,
    };
}


public class IdentifiableRequestLong : IIdentifiableRequest<long>, IRequest
{
    public HeaderMessage Header { get; set; } = new() { Header = string.Empty };
    public ReturnMessage Return { get; set; } = new() { ErrorCode = 0, Message = string.Empty, Status = false };
    public long Id { get; set; } = 0;
    public IdentifiableRequestLong() { }
    public IdentifiableRequestLong(long id) { Id = id; }
    public IdentifiableMessageLong MapTo() => new()
    {
        Header = Header,
        Return = Return,
        Id = Id,
    };
}

public class IdentifiableRequestShort : IIdentifiableRequest<short>, IRequest
{
    public HeaderMessage Header { get; set; } = new() { Header = string.Empty };
    public ReturnMessage Return { get; set; } = new() { ErrorCode = 0, Message = string.Empty, Status = false };
    public short Id { get; set; } = 0;
    public IdentifiableRequestShort() { }
    public IdentifiableRequestShort(short id) { Id = id; }
    public IdentifiableMessageShort MapTo() => new()
    {
        Header = Header,
        Return = Return,
        Id = Id,
    };
}