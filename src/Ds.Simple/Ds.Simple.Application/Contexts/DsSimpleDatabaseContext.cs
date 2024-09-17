using Ds.Base.EntityFramework.Contexts;
using Ds.Simple.Application.Contexts.Abstractions;
using Ds.Simple.Application.Maps;
using Microsoft.EntityFrameworkCore;

namespace Ds.Simple.Application.Contexts;

public class DsSimpleDatabaseContext : DatabaseContext, IDsSimpleDatabaseContext
{

    public DsSimpleDatabaseContext() : base(new DbContextOptionsBuilder<DatabaseContext>()
        .UseInMemoryDatabase(databaseName: "DsSimple").Options)
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

