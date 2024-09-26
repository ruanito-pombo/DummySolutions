using Ds.Base.EntityFramework.Contexts;
using Ds.Full.Domain.Contexts.Abstractions;
using Ds.Full.MySql.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using static Ds.Base.Domain.Utils.ConfigurationsUtil;
using static Ds.Full.MySql.Factories.DsFullDatabaseFactory;

namespace Ds.Full.MySql.Contexts;

public class DsFullDatabaseContext : DatabaseContext, IDsFullDatabaseContext
{
    public static bool HasDotNetEfCliDebugArgs { get => DotNetEfCliDebugArgs; }
    private static bool _firstInternalCustomizeCall = true;

    public DsFullDatabaseContext(DbContextOptions<DsFullDatabaseContext> options) : base(options)
    { if (HasDotNetEfCliDebugArgs) { WriteOutputLog("Creating Database Context"); } }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.ConfigureWarnings(warnings =>
            warnings.Ignore(CoreEventId.MultipleNavigationProperties));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        if (HasDotNetEfCliDebugArgs && _firstInternalCustomizeCall)
        { _firstInternalCustomizeCall = false; return; }

        if (HasDotNetEfCliDebugArgs)
        { WriteOutputLog("Applying Maps"); }

        DsFullDatabaseContextConfiguration.OnModelCreating(modelBuilder);
    }

}

