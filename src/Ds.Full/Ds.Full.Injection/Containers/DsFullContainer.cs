using Ds.Base.Domain.Containers.Abstractions;
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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using static Ds.Base.Domain.Utils.ConfigurationsUtil;

namespace Ds.Full.Injection.Containers;

public class DsFullContainer : DsContainer, IContainer
{

    private static DsFullContainer? _instance; public static DsFullContainer Instance { get => _instance ??= new(); }
    private readonly string _connectionString = string.Empty;
    private readonly DbContextOptions<DsFullDatabaseContext> _dbContextOptionsBuilder = new();

    public DsFullContainer() : base() { _instance ??= this; }
    public DsFullContainer(IAppInfo? appInfo, IAppSetting? appSetting, string[]? args = null) : base(appInfo ?? new AppInfo(), appSetting ?? new AppSetting(), args)
    {
        _connectionString = AppSetting.Type switch
        {
            ApplicationType.Grpc => ((IGrpcSetting)AppSetting).DatabaseSetting.ConnectionString,
            ApplicationType.WebApi => ((IWebApiSetting)AppSetting).DatabaseSetting.ConnectionString,
            _ => ((dynamic)AppSetting).Database.ConnectionString.ToString()
        };

        _dbContextOptionsBuilder = new DbContextOptionsBuilder<DsFullDatabaseContext>().UseMySql(_connectionString,
                ServerVersion.AutoDetect(_connectionString), configs => { configs.EnableStringComparisonTranslations(); }).Options;

        _instance ??= this;
    }

    public override bool Register()
    {
        if (DotNetEfCliDebugArgs) { return true; }

        try
        {
            Register<IDsFullDatabaseContext>(() => new DsFullDatabaseContext(_dbContextOptionsBuilder), Lifestyle.Scoped);
            Register<IInventoryBusiness, InventoryBusiness>(Lifestyle.Scoped);
            Register<IInventoryRepository, InventoryRepository>(Lifestyle.Scoped);
            Register<IPaymentBusiness, PaymentBusiness>(Lifestyle.Scoped);
            Register<IPaymentRepository, PaymentRepository>(Lifestyle.Scoped);
            Register<IPersonBusiness, PersonBusiness>(Lifestyle.Scoped);
            Register<IPersonRepository, PersonRepository>(Lifestyle.Scoped);
            Register<IRentalBusiness, RentalBusiness>(Lifestyle.Scoped);
            Register<IRentalRepository, RentalRepository>(Lifestyle.Scoped);
            Register<ITitleBusiness, TitleBusiness>(Lifestyle.Scoped);
            Register<ITitleRepository, TitleRepository>(Lifestyle.Scoped);
            Register<IUserBusiness, UserBusiness>(Lifestyle.Scoped);
            Register<IUserRepository, UserRepository>(Lifestyle.Scoped);

            return true;
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
    }


}
