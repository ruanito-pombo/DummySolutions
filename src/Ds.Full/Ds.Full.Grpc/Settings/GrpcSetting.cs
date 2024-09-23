using Ds.Base.Domain.Settings;
using Ds.Base.Grpc.Settings.Abstractions;

namespace Ds.Full.Grpc.Settings;

public class GrpcSetting : AppSetting, IGrpcSetting
{

    public DatabaseSetting DatabaseSetting { get; set; } = new();

}
