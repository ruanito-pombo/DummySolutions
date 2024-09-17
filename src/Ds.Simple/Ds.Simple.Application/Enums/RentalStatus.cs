using System.ComponentModel;

namespace Ds.Simple.Application.Enums;

public enum RentalStatus : byte
{

    [Description("Unknown")]
    Unknown = 0,

    [Description("Reserved")]
    Reserved,

    [Description("OnGoing")]
    OnGoing,

    [Description("Delayed")]
    Delayed,

    [Description("Strayed")]
    Strayed,

    [Description("Returned")]
    Returned,

}
