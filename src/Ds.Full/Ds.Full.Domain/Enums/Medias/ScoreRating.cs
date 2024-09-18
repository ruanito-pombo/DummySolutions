using System.ComponentModel;

namespace Ds.Full.Domain.Enums.Medias;

public enum ScoreRating : byte
{

    [Description("Unknown")]
    Unknown = 0,

    [Description("1 Star")]
    OneStar,

    [Description("2 Stars")]
    TwoStars,

    [Description("3 Stars")]
    ThreeStars,

    [Description("4 Stars")]
    FourStars,

    [Description("5 Stars")]
    FiveStars,

}
