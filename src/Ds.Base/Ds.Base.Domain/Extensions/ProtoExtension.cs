using Google.Protobuf.WellKnownTypes;
using static Ds.Base.Domain.Constants.DsBaseConstant;

namespace Ds.Base.Domain.Extensions;

public static class ProtoExtension
{

    public static ProtoTimestamp Cast(this DateTimeOffset dto) =>
        new(Timestamp.FromDateTime(dto.UtcDateTime), (int)dto.Offset.TotalSeconds);

    public static DateTimeOffset Cast(this ProtoTimestamp timestamp) =>
        new(timestamp.Date.ToDateTime(), TimeSpan.FromSeconds(timestamp.Offset));

    public static DateTimeOffset Cast(this Timestamp date, int offset) =>
        new(date.ToDateTime(), TimeSpan.FromSeconds(offset));

    public static TRepeatedMsg ToRepeatedField<TRepeatedMsg, TMsg>(this TRepeatedMsg msg, IEnumerable<TMsg> msgList)
            where TRepeatedMsg : class
    {
        try
        {
            (msg as dynamic).List.AddRange(msgList);
            return msg;
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }

}
