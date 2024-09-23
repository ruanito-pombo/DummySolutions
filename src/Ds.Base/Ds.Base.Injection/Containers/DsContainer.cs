using Ds.Base.Domain.Containers.Abstractions;
using Ds.Base.Domain.Infos;
using Ds.Base.Domain.Infos.Abstractions;
using Ds.Base.Domain.Settings;
using Ds.Base.Domain.Settings.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using static Ds.Base.Domain.Utils.ConfigurationsUtil;

namespace Ds.Base.Injection.Containers;

public class DsContainer : Container, IContainer
{
    private static IAppInfo _appInfo = new AppInfo(); public static IAppInfo AppInfo { get => _appInfo; }
    private static IAppSetting _appSetting = new AppSetting(); public static IAppSetting AppSetting { get => _appSetting; }
    private static bool _dotNetEfCliDebugArgs = false; public static bool DotNetEfCliDebugArgs { get =>  _dotNetEfCliDebugArgs; }

    public DsContainer() { InitializeContainer(); }
    public DsContainer(IAppInfo appInfo, IAppSetting appSetting, string[]? args = null) 
    {
        _dotNetEfCliDebugArgs = HasDotNetEfCliDebugArgs(args ?? []);
        InitializeContainer(appInfo, appSetting);
    }

    public virtual bool InitializeApplication(IApplicationBuilder applicationBuilder, bool? register = false, bool? verify = false)
    {
        applicationBuilder.UseSimpleInjector(this);
        if (register ?? false) { Register(); }
        if (verify ?? false) { Verify(); }

        return true;
    }
    public virtual bool InitializeContainer(IAppInfo? appInfo = null, IAppSetting? appSetting = null)
    {
        if (DotNetEfCliDebugArgs)
        { WriteOutputLog("Initializing the Container"); }

        if (appInfo != null) { _appInfo = appInfo; }
        if (appSetting != null) { _appSetting = appSetting; }
        
        Options.DefaultLifestyle = Lifestyle.Scoped;
        Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
        AsyncScopedLifestyle.BeginScope(this);

        return true;
    }
    public virtual bool InitializeServices(IServiceCollection services)
    {
        if (DotNetEfCliDebugArgs)
        { WriteOutputLog("Initializing Services"); }

        services.AddMvcCore();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSimpleInjector(this, options =>
        {
            options.AddAspNetCore().AddControllerActivation();
            options.AddLogging();
        });

        services.UseSimpleInjectorAspNetRequestScoping(this);

        return true;
    }
    public virtual bool Register()
    {
        if (DotNetEfCliDebugArgs)
        { WriteOutputLog("Registering Dependencies"); }

        return true;
    }

}