using System.ComponentModel;

namespace Ds.Full.Domain.Enums.Medias;

public enum EsrbRating : byte
{

    [Description("Unknown")]
    Unknown = 0,

    [Description("Pending")]
    Pending,

    [Description("Everyone")]
    Everyone,

    [Description("Everyone 10+")]
    Everyone10Plus,

    [Description("Teen 13+")]
    Teen13Plus,

    [Description("Mature 17+")]
    Mature17Plus,

    [Description("Adult 18+")]
    Adult18Plus,

}
