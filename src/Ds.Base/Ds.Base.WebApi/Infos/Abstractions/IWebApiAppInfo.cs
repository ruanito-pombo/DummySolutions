using Ds.Base.Domain.Infos.Abstractions;

namespace Ds.Base.WebApi.Infos.Abstractions;

public interface IWebApiAppInfo : IAppInfo
{

    string PublisherName { get; set; }
    string PublisherEmail { get; set; }
    string Url { get; set; }

}
