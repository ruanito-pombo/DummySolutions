using Google.Protobuf.Collections;
using static Ds.Base.Proto.Utils.ProtoUtil;

namespace Ds.Base.Grpc.Mappers;

public static class MessageMapper
{

    public static decimal ToDecimal<TMessage>(TMessage? decimalMsg) =>
        CastToDecimal(decimalMsg);
    public static TMessage ToDecimalMsg<TMessage>(decimal? decimalValue) where TMessage : class =>
        CastToDecimalMsg<TMessage>(decimalValue);
    public static DateTimeOffset ToDateTimeOffset<TMessage>(TMessage? dateTimeOffsetMsg) where TMessage : class =>
        CastToDateTimeOffset(dateTimeOffsetMsg);
    public static TMessage ToDateTimeOffsetMsg<TMessage>(DateTimeOffset? dateTimeOffsetValue) where TMessage : class =>
        CastToDateTimeOffsetMsg<TMessage>(dateTimeOffsetValue);
    public static IEnumerable<TMessage> ToEnumerable<TMessage>(RepeatedField<TMessage>? repeatedField) where TMessage : class => 
        CastToEnumerable(repeatedField);
    public static RepeatedField<TModel> ToRepeatedFieldMsg<TModel>(IEnumerable<TModel>? modelList) where TModel : class => 
        CastToRepeatedFieldMsg(modelList);

}
