using Google.Protobuf.WellKnownTypes;

namespace Ds.Base.Domain.Constants;

public static class DsBaseConstant
{

    public readonly struct ProtoTimestamp(Timestamp date, int offset)
    {
        public readonly Timestamp Date { get; } = date;
        public readonly int Offset { get; } = offset;
    }
}
