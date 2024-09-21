using Ds.Base.Domain.Enums;
using Ds.Base.Domain.Infos;
using Ds.Base.Domain.Infos.Abstractions;
using Ds.Base.Domain.Settings;
using Ds.Base.Domain.Settings.Abstractions;
using Ds.Base.Grpc.Settings.Abstractions;
using Ds.Base.Injection.Containers;
using Ds.Base.WebApi.Settings.Abstractions;
using Ds.Full.Domain.Businesses.Abstractions.Finances;
using Ds.Full.Domain.Businesses.Abstractions.Inventories;
using Ds.Full.Domain.Businesses.Abstractions.Medias;
using Ds.Full.Domain.Businesses.Abstractions.Persons;
using Ds.Full.Domain.Businesses.Abstractions.Rentals;
using Ds.Full.Domain.Businesses.Abstractions.Staffs;
using Ds.Full.Domain.Businesses.Finances;
using Ds.Full.Domain.Businesses.Inventories;
using Ds.Full.Domain.Businesses.Medias;
using Ds.Full.Domain.Businesses.Persons;
using Ds.Full.Domain.Businesses.Rentals;
using Ds.Full.Domain.Businesses.Staffs;
using Ds.Full.Domain.Contexts.Abstractions;
using Ds.Full.Domain.Repositories.Abstractions.Finances;
using Ds.Full.Domain.Repositories.Abstractions.Inventories;
using Ds.Full.Domain.Repositories.Abstractions.Medias;
using Ds.Full.Domain.Repositories.Abstractions.Persons;
using Ds.Full.Domain.Repositories.Abstractions.Rentals;
using Ds.Full.Domain.Repositories.Abstractions.Staffs;
using Ds.Full.MySql.Contexts;
using Ds.Full.MySql.Repositories.Finances;
using Ds.Full.MySql.Repositories.Inventories;
using Ds.Full.MySql.Repositories.Medias;
using Ds.Full.MySql.Repositories.Persons;
using Ds.Full.MySql.Repositories.Rentals;
using Ds.Full.MySql.Repositories.Staffs;
using SimpleInjector;

namespace Ds.Full.Injection.Containers;

public class DsFullContainer : DsContainer
{

    private static DsFullContainer? _instance; public static DsFullContainer Instance { get => _instance ??= new(); }

    public DsFullContainer() : base() { _instance ??= this; }
    public DsFullContainer(IAppInfo? appInfo, IAppSetting? appSetting) : base(appInfo ?? new AppInfo(), appSetting ?? new AppSetting()) { _instance ??= this; }

    public void Initialize()
    {
        Register();
    }

    public override void Register()
    {
        try
        {
            Action registerDatabase = AppSetting.Type switch
            {
                ApplicationType.Grpc => () => Register<IDsFullDatabaseContext>(() => new DsFullDatabaseContext(
                    ((IGrpcAppSetting)AppSetting).DatabaseSetting.ConnectionString), Lifestyle.Singleton),
                ApplicationType.WebApi => () => Register<IDsFullDatabaseContext>(() => new DsFullDatabaseContext(
                    ((IWebApiAppSetting)AppSetting).DatabaseSetting.ConnectionString), Lifestyle.Singleton),
                _ => throw new Exception("NOCONNECTIONSTRING")
            }; registerDatabase();

            Register<IInventoryBusiness, InventoryBusiness>(Lifestyle.Singleton);
            Register<IInventoryRepository, InventoryRepository>(Lifestyle.Singleton);
            Register<IPaymentBusiness, PaymentBusiness>(Lifestyle.Singleton);
            Register<IPaymentRepository, PaymentRepository>(Lifestyle.Singleton);
            Register<IPersonBusiness, PersonBusiness>(Lifestyle.Singleton);
            Register<IPersonRepository, PersonRepository>(Lifestyle.Singleton);
            Register<IRentalBusiness, RentalBusiness>(Lifestyle.Singleton);
            Register<IRentalRepository, RentalRepository>(Lifestyle.Singleton);
            Register<ITitleBusiness, TitleBusiness>(Lifestyle.Singleton);
            Register<ITitleRepository, TitleRepository>(Lifestyle.Singleton);
            Register<IUserBusiness, UserBusiness>(Lifestyle.Singleton);
            Register<IUserRepository, UserRepository>(Lifestyle.Singleton);

            Verify();

        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }


}
