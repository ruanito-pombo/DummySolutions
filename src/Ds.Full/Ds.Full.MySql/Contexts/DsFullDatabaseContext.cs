using Ds.Base.EntityFramework.Contexts;
using Ds.Full.Domain.Contexts.Abstractions;
using Ds.Full.MySql.Maps.Finances;
using Ds.Full.MySql.Maps.Inventories;
using Ds.Full.MySql.Maps.Medias;
using Ds.Full.MySql.Maps.Persons;
using Ds.Full.MySql.Maps.Rentals;
using Ds.Full.MySql.Maps.Staffs;
using Microsoft.EntityFrameworkCore;

namespace Ds.Full.MySql.Contexts;

public class DsFullDatabaseContext : DatabaseContext, IDsFullDatabaseContext
{

    public DsFullDatabaseContext(string connectionString) : base(new DbContextOptionsBuilder<DatabaseContext>()
        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), options => { options.EnableStringComparisonTranslations(); }).Options)
    {
        SaveChanges();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        base.OnConfiguring(optionsBuilder);
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CategoryMap());
        modelBuilder.ApplyConfiguration(new InventoryMap());
        modelBuilder.ApplyConfiguration(new PaymentMap());
        modelBuilder.ApplyConfiguration(new PersonMap());
        modelBuilder.ApplyConfiguration(new PersonContactMap());
        modelBuilder.ApplyConfiguration(new PersonAddressMap());
        modelBuilder.ApplyConfiguration(new ProfileMap());
        modelBuilder.ApplyConfiguration(new RentalMap());
        modelBuilder.ApplyConfiguration(new RentalItemMap());
        modelBuilder.ApplyConfiguration(new TitleMap());
        modelBuilder.ApplyConfiguration(new UserMap());
    }

}

