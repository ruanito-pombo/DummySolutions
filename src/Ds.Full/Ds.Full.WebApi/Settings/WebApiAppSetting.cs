using Ds.Base.Domain.Settings;
using Ds.Base.WebApi.Settings.Abstractions;

namespace Ds.Full.WebApi.Settings;

public class WebApiAppSetting : AppSetting, IWebApiAppSetting
{

    public DatabaseSetting DatabaseSetting { get; set; } = new();

}
