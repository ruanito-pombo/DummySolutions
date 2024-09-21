using Ds.Base.Domain.Infos.Abstractions;

namespace Ds.Base.Grpc.Infos.Abstractions;

public interface IGrpcAppInfo : IAppInfo
{

    string PublisherName { get; set; }
    string PublisherEmail { get; set; }
    string Url { get; set; }

}
