using Ds.Base.Domain.Infos;
using Ds.Base.Domain.Infos.Abstractions;
using Ds.Base.Domain.Settings;
using Ds.Base.Domain.Settings.Abstractions;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Ds.Base.Injection.Containers;

public class DsContainer : Container
{
    private static IAppInfo _appInfo = new AppInfo(); public static IAppInfo AppInfo { get => _appInfo; }
    private static IAppSetting _appSetting = new AppSetting(); public static IAppSetting AppSetting { get => _appSetting; }

    public DsContainer()
    {
        Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
        AsyncScopedLifestyle.BeginScope(this);
    }

    public DsContainer(IAppInfo appInfo, IAppSetting appSetting)
    {
        _appInfo = appInfo;
        _appSetting = appSetting;

        Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
        AsyncScopedLifestyle.BeginScope(this);
    }

    public virtual void Register()
    {
        Verify();
    }

}