using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;

namespace Ds.Base.Proto.Utils;

public static class ProtoUtil
{

    private const decimal DecimalNanoFactor = 1_000_000_000;

    public static decimal CastToDecimal<TMessage>(TMessage? decimalMsg) => decimalMsg != null
        ? (((dynamic)decimalMsg).Units + ((dynamic)decimalMsg).Nanos) / DecimalNanoFactor
        : 0;
    public static TMessage CastToDecimalMsg<TMessage>(decimal? decimalValue) where TMessage : class => decimalValue != null
        ? CreateDecimalMsg<TMessage>((decimal)decimalValue)
        : Activator.CreateInstance<TMessage>();
    public static DateTimeOffset CastToDateTimeOffset<TMessage>(TMessage? dateTimeOffsetMsg) where TMessage : class => dateTimeOffsetMsg != null
        ? new DateTimeOffset(((dynamic)dateTimeOffsetMsg).Date.ToDateTime(), TimeSpan.FromSeconds(((dynamic)dateTimeOffsetMsg).Offset))
        : DateTimeOffset.MinValue;
    public static TMessage CastToDateTimeOffsetMsg<TMessage>(DateTimeOffset? dateTimeOffsetValue) where TMessage : class => dateTimeOffsetValue != null
        ? CreateDateTimeOffsetMsg<TMessage>((DateTimeOffset)dateTimeOffsetValue)
        : Activator.CreateInstance<TMessage>();
    public static IEnumerable<TModel> CastToEnumerable<TModel>(RepeatedField<TModel>? repeatedList) where TModel : class => repeatedList != null
        ? repeatedList.Select(s => s)
        : [];
    public static RepeatedField<TModel> CastToRepeatedFieldMsg<TModel>(IEnumerable<TModel>? modelList) where TModel : class => modelList != null
        ? CreateRepeatedFieldMsg(modelList)
        : [];

    private static TMessage CreateDecimalMsg<TMessage>(decimal decimalValue)
    {
        var decimalMessage = Activator.CreateInstance<TMessage>();
        ((dynamic)decimalMessage!).Units = decimal.ToInt64(decimalValue);
        ((dynamic)decimalMessage!).Nanos = decimal.ToInt32((decimalValue - decimal.ToInt64(decimalValue)) * DecimalNanoFactor);
        
        return decimalMessage;
    }
    private static TMessage CreateDateTimeOffsetMsg<TMessage>(DateTimeOffset dateTimeOffsetValue)
    {
        var dateTimeOffsetMessage = Activator.CreateInstance<TMessage>();
        ((dynamic)dateTimeOffsetMessage!).Date = Timestamp.FromDateTime((dateTimeOffsetValue).UtcDateTime);
        ((dynamic)dateTimeOffsetMessage!).Offset = (int)(dateTimeOffsetValue).Offset.TotalSeconds;
        return dateTimeOffsetMessage;
    }
    private static RepeatedField<TModel> CreateRepeatedFieldMsg<TModel>(IEnumerable<TModel> modelList)
    {
        var repeatedField = new RepeatedField<TModel>();
        repeatedField.AddRange(modelList);
        return repeatedField;
    }

}
