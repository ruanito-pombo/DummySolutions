using System.ComponentModel;

namespace Ds.Simple.Application.Enums;

[Flags]
public enum ContactType : short
{

    [Description("Unknown")]
    Unknown = 0,

    [Description("Email")]
    Email = 1 << 0,

    [Description("Landline Phone")]
    LandlinePhone = 1 << 1,

    [Description("Mobile Phone")]
    MobilePhone = 1 << 2,

    [Description("WhatsApp")]
    WhatsApp = 1 << 3,

}
