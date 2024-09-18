using System.ComponentModel;

namespace Ds.Full.Domain.Enums.Medias;

public enum ContentType : byte
{

    [Description("Unknown")]
    Unknown = 0,

    [Description("Book")]
    Book,

    [Description("Music")]
    Music,

    [Description("Video")]
    Video,

    [Description("Game")]
    Game,

}
