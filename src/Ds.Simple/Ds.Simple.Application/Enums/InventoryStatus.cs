using System.ComponentModel;

namespace Ds.Simple.Application.Enums;

public enum InventoryStatus : byte
{

    [Description("Unknown")]
    Unknown = 0,

    [Description("Available")]
    Available,

    [Description("Reserved")]
    Reserved,

    [Description("Rented")]
    Rented,

    [Description("Lost")]
    Lost,

    [Description("Sold")]
    Sold,

}
