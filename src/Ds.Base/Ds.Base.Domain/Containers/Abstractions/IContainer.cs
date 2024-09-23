using Ds.Base.Domain.Infos.Abstractions;
using Ds.Base.Domain.Settings.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ds.Base.Domain.Containers.Abstractions;

public interface IContainer
{

    static abstract IAppInfo AppInfo { get; }
    static abstract IAppSetting AppSetting { get; }
    static abstract bool DotNetEfCliDebugArgs { get; }

    bool InitializeApplication(IApplicationBuilder applicationBuilder, bool? register = false, bool? verify = false);
    bool InitializeContainer(IAppInfo? appInfo = null, IAppSetting? appSetting = null);
    bool InitializeServices(IServiceCollection services);
    bool Register();

}
