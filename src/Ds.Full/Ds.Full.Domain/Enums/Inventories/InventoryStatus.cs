using System.ComponentModel;

namespace Ds.Full.Domain.Enums.Inventories;

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
