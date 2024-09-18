using System.ComponentModel;

namespace Ds.Full.Domain.Enums.Medias;

public enum MediaType : byte
{

    [Description("Unknown")]
    Unknown = 0,

    [Description("Paper")]
    Paper,

    [Description("Vinyl")]
    Vinyl,

    [Description("Cassette")]
    Cassette,

    [Description("Betamax")]
    Betamax,

    [Description("Vhs")]
    Vhs,

    [Description("Cd")]
    Cd,

    [Description("Dvd")]
    Dvd,

    [Description("BluRay")]
    BluRay,

    [Description("HdDvd")]
    HdDvd,

    [Description("Cartridge")]
    Cartridge,

    [Description("Disquete")]
    Disquete,

}
