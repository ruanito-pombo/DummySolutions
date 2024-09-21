using Ds.Base.Domain.Infos;
using Ds.Base.WebApi.Infos.Abstractions;

namespace Ds.Full.WebApi.Infos;

public class WebApiAppInfo : AppInfo, IWebApiAppInfo
{

    public string PublisherName { get; set; } = string.Empty;
    public string PublisherEmail { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;

}
