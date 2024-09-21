using Ds.Base.Domain.Settings;
using Ds.Base.Grpc.Settings.Abstractions;

namespace Ds.Full.Grpc.Settings;

public class GrpcAppSetting : AppSetting, IGrpcAppSetting
{

    public DatabaseSetting DatabaseSetting { get; set; } = new();

}
