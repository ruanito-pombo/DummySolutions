using System.ComponentModel;

namespace Ds.Simple.Application.Enums;

[Flags]
public enum AddressType : short
{

    [Description("Unknown")]
    Unknown = 0,

    [Description("Personal")]
    Personal = 1 << 0,

    [Description("Professional")]
    Professional = 1 << 1,

    [Description("Vacation")]
    Vacation = 1 << 2,

}
