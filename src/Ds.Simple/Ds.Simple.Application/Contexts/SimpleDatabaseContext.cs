using Ds.Base.Core.Contexts;
using Ds.Base.Core.Contexts.Abstractions;
using Ds.Simple.Application.Maps;
using Microsoft.EntityFrameworkCore;

namespace Ds.Simple.Application.Contexts;

public class SimpleDatabaseContext : DatabaseContext, IDatabaseContext
{

    public SimpleDatabaseContext() : base(new DbContextOptionsBuilder<DatabaseContext>()
        .UseInMemoryDatabase(databaseName: "SimpleDatabase").Options)
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

