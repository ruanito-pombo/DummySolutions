using Ds.Base.Domain.Infos;
using Ds.Base.Grpc.Infos.Abstractions;

namespace Ds.Full.Grpc.Infos;

public class GrpcAppInfo : AppInfo, IGrpcAppInfo
{

    public string PublisherName { get; set; } = string.Empty;
    public string PublisherEmail { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;

}
