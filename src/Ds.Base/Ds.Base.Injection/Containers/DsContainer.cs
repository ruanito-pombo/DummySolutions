using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Ds.Base.Injection.Containers;

public class DsContainer : Container
{

    public DsContainer()
    {
        Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
        AsyncScopedLifestyle.BeginScope(this);
    }

    public void Register()
    {
        Verify();
    }

}