using Ds.Base.Domain.Grpcs.Results.Abstractions;
using Ds.Base.Grpc.Protos;

namespace Ds.Base.Grpc.Results;

public class AuditableResult<TId> : IAuditableResult<TId>, IResult
    where TId : struct
{
    public HeaderMessage Header { get; set; } = new() { Header = string.Empty };
    public ReturnMessage Return { get; set; } = new() { ErrorCode = 0, Message = string.Empty, Status = false };
    public TId Id { get; set; } = default;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
}

public class AuditableResultInt : IAuditableResult<int>, IResult
{
    public HeaderMessage Header { get; set; } = new() { Header = string.Empty };
    public ReturnMessage Return { get; set; } = new() { ErrorCode = 0, Message = string.Empty, Status = false };
    public int Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableResultInt() { }
    public AuditableResultInt(int id) { Id = id; }
    public AuditableResultInt(AuditableMessageInt proto) => MapFrom(proto);

    public static AuditableResultInt MapFrom(AuditableMessageInt? proto) => proto is null ? new() : new()
    {
        Header = proto.Header,
        Return = proto.Return,
        Id = proto.Id,
        CreateDate = new DateTimeOffset(proto.CreateDate.ToDateTime(), TimeSpan.FromSeconds(proto.CreateOffset)),
        UpdateDate = new DateTimeOffset(proto.CreateDate.ToDateTime(), TimeSpan.FromSeconds(proto.CreateOffset)),
    };
}

public class AuditableResultLong : IAuditableResult<long>, IResult
{
    public HeaderMessage Header { get; set; } = new() { Header = string.Empty };
    public ReturnMessage Return { get; set; } = new() { ErrorCode = 0, Message = string.Empty, Status = false };
    public long Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableResultLong() { }
    public AuditableResultLong(long id) { Id = id; }
    public AuditableResultLong(AuditableMessageLong proto) => MapFrom(proto);

    public static AuditableResultLong MapFrom(AuditableMessageLong? proto) => proto is null ? new() : new()
    {
        Header = proto.Header,
        Return = proto.Return,
        Id = proto.Id,
        CreateDate = new DateTimeOffset(proto.CreateDate.ToDateTime(), TimeSpan.FromSeconds(proto.CreateOffset)),
        UpdateDate = new DateTimeOffset(proto.CreateDate.ToDateTime(), TimeSpan.FromSeconds(proto.CreateOffset)),
    };
}

public class AuditableResultShort : IAuditableResult<short>, IResult
{
    public HeaderMessage Header { get; set; } = new() { Header = string.Empty };
    public ReturnMessage Return { get; set; } = new() { ErrorCode = 0, Message = string.Empty, Status = false };
    public short Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableResultShort() { }
    public AuditableResultShort(short id) { Id = id; }
    public AuditableResultShort(AuditableMessageShort proto) => MapFrom(proto);

    public static AuditableResultShort MapFrom(AuditableMessageShort? proto) => proto is null ? new() : new()
    {
        Header = proto.Header,
        Return = proto.Return,
        Id = (short)proto.Id,
        CreateDate = new DateTimeOffset(proto.CreateDate.ToDateTime(), TimeSpan.FromSeconds(proto.CreateOffset)),
        UpdateDate = new DateTimeOffset(proto.CreateDate.ToDateTime(), TimeSpan.FromSeconds(proto.CreateOffset)),
    };
}