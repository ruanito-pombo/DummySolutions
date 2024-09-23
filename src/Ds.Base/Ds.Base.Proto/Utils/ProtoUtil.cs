using Ds.Base.Proto.Protos;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;

namespace Ds.Base.Proto.Utils;

public static class ProtoUtil
{

    private const decimal DecimalNanoFactor = 1_000_000_000;
    private static ArgumentNullException ThrowArgumentNullException(string name) =>
        throw new($"{name} can't be null");

    public static decimal CastToDecimal(dynamic? decimalMsg) => decimalMsg != null
        ? (decimalMsg.Units + decimalMsg.Nanos) / DecimalNanoFactor
        : 0;

    public static dynamic CastToDecimalMsg(decimal? decimalValue) => decimalValue != null 
        ? new { Units = decimal.ToInt64((decimal)decimalValue), Nanos = decimal.ToInt32(((decimal)decimalValue - decimal.ToInt64((decimal)decimalValue)) * DecimalNanoFactor) }
        : ThrowArgumentNullException(nameof(decimalValue));

    public static DateTimeOffset CastToDateTimeOffset(dynamic? dateTimeOffsetMsg) => dateTimeOffsetMsg != null
        ? new DateTimeOffset(dateTimeOffsetMsg.Date.ToDateTime(), TimeSpan.FromSeconds(dateTimeOffsetMsg.Offset))
        : DateTimeOffset.MinValue;

    public static dynamic CastToDateTimeOffsetMsg(DateTimeOffset? dateTimeOffsetValue) => dateTimeOffsetValue != null
        ? new { Date = Timestamp.FromDateTime(((DateTimeOffset)dateTimeOffsetValue).UtcDateTime), Offset = (int)((DateTimeOffset)dateTimeOffsetValue).Offset.TotalSeconds }
        : ThrowArgumentNullException(nameof(dateTimeOffsetValue));

    public static IEnumerable<TModel> CastToEnumerable<TModel>(RepeatedField<TModel> repeatedList) where TModel : class => repeatedList != null
        ? repeatedList.Select(s => s)
        : [];

    public static RepeatedField<TModel> CastToRepeatedFieldMsg<TModel>(IEnumerable<TModel> modelList) where TModel : class => modelList != null
        ? CreateRepeatedFieldMsg(modelList)
        : [];


    private static RepeatedField<TModel> CreateRepeatedFieldMsg<TModel>(IEnumerable<TModel> modelList)
    {
        var repeatedField = new RepeatedField<TModel>();
        repeatedField.AddRange(modelList);
        return repeatedField;
    }

}
