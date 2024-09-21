using Ds.Base.Domain.Extensions;
using Google.Protobuf.WellKnownTypes;
using static Ds.Base.Domain.Constants.DsBaseConstant;

namespace Ds.Base.Grpc.Mappers;

public static class RequestMapper
{

    public static ProtoTimestamp Cast(DateTimeOffset dto) => dto.Cast();
    public static DateTimeOffset Cast(ProtoTimestamp timestamp) => timestamp.Cast();
    public static DateTimeOffset Cast(Timestamp date, int offset) => date.Cast(offset);
    public static TRepeatedMsg ToRepeatedField<TRepeatedMsg, TMsg>(TRepeatedMsg msg, IEnumerable<TMsg> msgList)
        where TRepeatedMsg : class => msg.ToRepeatedField(msgList);

}
