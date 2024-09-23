using Ds.Base.Domain.Infos.Abstractions;

namespace Ds.Base.WebApi.Infos.Abstractions;

public interface IWebApiInfo : IAppInfo
{

    string PublisherName { get; set; }
    string PublisherEmail { get; set; }
    string Url { get; set; }

}
