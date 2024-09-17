using System.ComponentModel;

namespace Ds.Simple.Application.Enums;

[Flags]
public enum PersonType : int
{

    [Description("Unknown")]
    Unknown = 0,

    [Description("User")]
    User = 1 << 0,

    [Description("Staff")]
    Staff = 1 << 1,

    [Description("Customer")]
    Customer = 1 << 2,

    [Description("Supplier")]
    Supplier = 1 << 3,

    [Description("Author")]
    Author = 1 << 4,

    [Description("Director")]
    Director = 1 << 5,

}
