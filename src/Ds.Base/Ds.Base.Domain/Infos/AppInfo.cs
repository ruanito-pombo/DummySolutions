using Ds.Base.Domain.Infos.Abstractions;

namespace Ds.Base.Domain.Infos;

public class AppInfo : Info, IAppInfo
{

    public string Version { get; set; } = string.Empty;
    public DateTimeOffset StartDateTimeOffset { get; set; } = DateTimeOffset.UtcNow;

}
