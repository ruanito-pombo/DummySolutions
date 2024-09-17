using Ds.Simple.Application.Businesses;
using Ds.Simple.Application.Businesses.Abstractions;
using Ds.Simple.Application.Contexts;
using Ds.Simple.Application.Contexts.Abstractions;
using Ds.Simple.Application.Repositories;
using Ds.Simple.Application.Repositories.Abstractions;
using Ds.Simple.Application.Services;
using Ds.Simple.Application.Services.Abstractions;
using Ds.Simple.Application.Tuis;
using Ds.Simple.Application.Tuis.Abstractions;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Ds.Simple.Application.Containers;

public class DsSimpleContainer : Container
{

    public DsSimpleContainer()
    {
        Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
        AsyncScopedLifestyle.BeginScope(this);
    }

    public void Register()
    {
        Register<IDsSimpleDatabaseContext, DsSimpleDatabaseContext>(Lifestyle.Singleton);
        Register<IInventoryBusiness, InventoryBusiness>(Lifestyle.Singleton);
        Register<IInventoryRepository, InventoryRepository>(Lifestyle.Singleton);
        Register<IInventoryService, InventoryService>(Lifestyle.Singleton);
        Register<IPaymentBusiness, PaymentBusiness>(Lifestyle.Singleton);
        Register<IPaymentRepository, PaymentRepository>(Lifestyle.Singleton);
        Register<IPaymentService, PaymentService>(Lifestyle.Singleton);
        Register<IPersonBusiness, PersonBusiness>(Lifestyle.Singleton);
        Register<IPersonRepository, PersonRepository>(Lifestyle.Singleton);
        Register<IPersonService, PersonService>(Lifestyle.Singleton);
        Register<IRentalBusiness, RentalBusiness>(Lifestyle.Singleton);
        Register<IRentalRepository, RentalRepository>(Lifestyle.Singleton);
        Register<IRentalService, RentalService>(Lifestyle.Singleton);
        Register<ITitleBusiness, TitleBusiness>(Lifestyle.Singleton);
        Register<ITitleRepository, TitleRepository>(Lifestyle.Singleton);
        Register<ITitleService, TitleService>(Lifestyle.Singleton);
        Register<IUserBusiness, UserBusiness>(Lifestyle.Singleton);
        Register<IUserRepository, UserRepository>(Lifestyle.Singleton);
        Register<IUserService, UserService>(Lifestyle.Singleton);
        Register<IMainTui, MainTui>(Lifestyle.Singleton);

        Verify();
    }

}
