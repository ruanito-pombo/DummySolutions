﻿using Ds.Base.Domain.Settings;
using Ds.Base.Domain.Settings.Abstractions;

namespace Ds.Base.Grpc.Settings.Abstractions;

public interface IGrpcSetting : IAppSetting
{

    DatabaseSetting DatabaseSetting { get; set; }

}
