using Ds.Base.Domain.Settings;
using Ds.Base.WebApi.Settings.Abstractions;

namespace Ds.Full.WebApi.Settings;

public class WebApiSetting : AppSetting, IWebApiSetting
{

    public DatabaseSetting DatabaseSetting { get; set; } = new();

}
