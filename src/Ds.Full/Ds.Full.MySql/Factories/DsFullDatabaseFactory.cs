using Ds.Base.Domain.Utils;
using Ds.Full.MySql.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using static Ds.Base.Domain.Utils.ConfigurationsUtil;

namespace Ds.Full.MySql.Factories;

public class DsFullDatabaseFactory : IDesignTimeDbContextFactory<DsFullDatabaseContext>
{
    
    private static DsFullDatabaseFactory? _instance; public static DsFullDatabaseFactory Instance { get => _instance ??= new(); }
    private static bool _dotNetEfCliDebugArgs = false; public static bool DotNetEfCliDebugArgs { get => _dotNetEfCliDebugArgs; }

    public DsFullDatabaseFactory() { _instance = this; }

    public DsFullDatabaseContext CreateDbContext(string[] args)
    {
        _dotNetEfCliDebugArgs = HasDotNetEfCliDebugArgs(args);

        var connectionString = ConfigurationsUtil.GetConfigurationRoot().GetSection("GrpcSetting")
            .GetSection("DatabaseSetting").GetValue<string>("ConnectionString");

        if (!string.IsNullOrWhiteSpace(connectionString))
        {
            return new DsFullDatabaseContext(new DbContextOptionsBuilder<DsFullDatabaseContext>().UseMySql(connectionString,
                ServerVersion.AutoDetect(connectionString), options => { options.EnableStringComparisonTranslations(); }).Options);
        }

        throw new Exception("Unable to create dbcontext");
    }

}
