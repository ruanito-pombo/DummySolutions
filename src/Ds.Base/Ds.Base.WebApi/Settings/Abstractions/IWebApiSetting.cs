using Ds.Base.Domain.Settings;
using Ds.Base.Domain.Settings.Abstractions;

namespace Ds.Base.WebApi.Settings.Abstractions;

public interface IWebApiSetting : IAppSetting
{

    DatabaseSetting DatabaseSetting { get; set; }

}
