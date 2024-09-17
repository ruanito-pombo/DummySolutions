using Ds.Base.Domain.Grpcs.Results.Abstractions;
using Ds.Base.Grpc.Protos;

namespace Ds.Base.Grpc.Results;

public class IdentifiableResult<TId> : IIdentifiableResult<TId>, IResult
    where TId : struct
{
    public HeaderMessage Header { get; set; } = new() { Header = string.Empty };
    public ReturnMessage Return { get; set; } = new() { ErrorCode = 0, Message = string.Empty, Status = false };
    public TId Id { get; set; } = default;
}

public class IdentifiableResultInt : IIdentifiableResult<int>, IResult
{
    public HeaderMessage Header { get; set; } = new() { Header = string.Empty };
    public ReturnMessage Return { get; set; } = new() { ErrorCode = 0, Message = string.Empty, Status = false };
    public int Id { get; set; } = 0;
    public IdentifiableResultInt() { }
    public IdentifiableResultInt(int id) { Id = id; }
    public IdentifiableResultInt(IdentifiableMessageInt proto) => MapFrom(proto);

    public static IdentifiableResultInt MapFrom(IdentifiableMessageInt? proto) => proto is null ? new() : new()
    {
        Header = proto.Header,
        Return = proto.Return,
        Id = proto.Id,
    };
}

public class IdentifiableResultLong : IIdentifiableResult<long>, IResult
{
    public HeaderMessage Header { get; set; } = new() { Header = string.Empty };
    public ReturnMessage Return { get; set; } = new() { ErrorCode = 0, Message = string.Empty, Status = false };
    public long Id { get; set; } = 0;
    public IdentifiableResultLong() { }
    public IdentifiableResultLong(long id) { Id = id; }
    public IdentifiableResultLong(IdentifiableMessageLong proto) => MapFrom(proto);

    public static IdentifiableResultLong MapFrom(IdentifiableMessageLong? proto) => proto is null ? new() : new()
    {
        Header = proto.Header,
        Return = proto.Return,
        Id = proto.Id,
    };
}

public class IdentifiableResultShort : IIdentifiableResult<short>, IResult
{
    public HeaderMessage Header { get; set; } = new() { Header = string.Empty };
    public ReturnMessage Return { get; set; } = new() { ErrorCode = 0, Message = string.Empty, Status = false };
    public short Id { get; set; } = 0;
    public IdentifiableResultShort() { }
    public IdentifiableResultShort(short id) { Id = id; }
    public IdentifiableResultShort(IdentifiableMessageShort proto) => MapFrom(proto);

    public static IdentifiableResultShort MapFrom(IdentifiableMessageShort? proto) => proto is null ? new() : new()
    {
        Header = proto.Header,
        Return = proto.Return,
        Id = (short)proto.Id,
    };
}