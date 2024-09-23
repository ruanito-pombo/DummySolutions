using Google.Protobuf.Collections;
using static Ds.Base.Proto.Utils.ProtoUtil;

namespace Ds.Base.Grpc.Mappers;

public static class RequestMapper
{

    public static decimal ToDecimal(dynamic decimalMsg) => CastToDecimal(decimalMsg);
    public static dynamic ToDecimalMsg<TMsg>(decimal decimalValue) => CastToDecimalMsg(decimalValue);
    public static DateTimeOffset ToDateTimeOffset(dynamic dateTimeOffsetMsg) => CastToDateTimeOffset(dateTimeOffsetMsg);
    public static dynamic ToDateTimeOffsetMsg(DateTimeOffset dateTimeOffsetValue) => CastToDateTimeOffsetMsg(dateTimeOffsetValue);
    public static IEnumerable<TMsg> ToEnumerable<TMsg>(RepeatedField<TMsg> repeatedField) 
        where TMsg : class => CastToEnumerable(repeatedField);
    public static RepeatedField<TModel> ToRepeatedFieldMsg<TModel>(IEnumerable<TModel> modelList)
        where TModel : class => CastToRepeatedFieldMsg(modelList);

}
