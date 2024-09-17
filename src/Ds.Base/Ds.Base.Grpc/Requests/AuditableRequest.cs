using Ds.Base.Domain.Grpcs.Requests.Abstractions;
using Ds.Base.Grpc.Protos;
using Google.Protobuf.WellKnownTypes;

namespace Ds.Base.Grpc.Requests;

public class AuditableRequest<TId> : IAuditableRequest<TId>, IRequest
    where TId : struct
{
    public HeaderMessage Header { get; set; } = new() { Header = string.Empty };
    public ReturnMessage Return { get; set; } = new() { ErrorCode = 0, Message = string.Empty, Status = false };
    public TId Id { get; set; } = default;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
}

public class AuditableRequestInt : IAuditableRequest<int>, IRequest
{
    public HeaderMessage Header { get; set; } = new() { Header = string.Empty };
    public ReturnMessage Return { get; set; } = new() { ErrorCode = 0, Message = string.Empty, Status = false };
    public int Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableRequestInt() { }
    public AuditableRequestInt(int id) { Id = id; }
    public AuditableMessageInt MapTo() => new()
    {
        Header = Header,
        Return = Return,
        Id = Id,
        CreateDate = Timestamp.FromDateTime(CreateDate.UtcDateTime),
        CreateOffset = (int)CreateDate.Offset.TotalSeconds,
        UpdateDate = Timestamp.FromDateTime(CreateDate.UtcDateTime),
        UpdateOffset = (int)CreateDate.Offset.TotalSeconds,
    };
}

public class AuditableRequestLong : IAuditableRequest<long>, IRequest
{
    public HeaderMessage Header { get; set; } = new() { Header = string.Empty };
    public ReturnMessage Return { get; set; } = new() { ErrorCode = 0, Message = string.Empty, Status = false };
    public long Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableRequestLong() { }
    public AuditableRequestLong(long id) { Id = id; }
    public AuditableMessageLong MapTo() => new()
    {
        Header = Header,
        Return = Return,
        Id = Id,
        CreateDate = Timestamp.FromDateTime(CreateDate.UtcDateTime),
        CreateOffset = (int)CreateDate.Offset.TotalSeconds,
        UpdateDate = Timestamp.FromDateTime(CreateDate.UtcDateTime),
        UpdateOffset = (int)CreateDate.Offset.TotalSeconds,
    };
}

public class AuditableRequestShort : IAuditableRequest<short>, IRequest
{
    public HeaderMessage Header { get; set; } = new() { Header = string.Empty };
    public ReturnMessage Return { get; set; } = new() { ErrorCode = 0, Message = string.Empty, Status = false };
    public short Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableRequestShort() { }
    public AuditableRequestShort(short id) { Id = id; }
    public AuditableMessageShort MapTo() => new()
    {
        Header = Header,
        Return = Return,
        Id = Id,
        CreateDate = Timestamp.FromDateTime(CreateDate.UtcDateTime),
        CreateOffset = (int)CreateDate.Offset.TotalSeconds,
        UpdateDate = Timestamp.FromDateTime(CreateDate.UtcDateTime),
        UpdateOffset = (int)CreateDate.Offset.TotalSeconds,
    };
}