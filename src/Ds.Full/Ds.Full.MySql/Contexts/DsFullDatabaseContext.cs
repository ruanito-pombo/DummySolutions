using Ds.Base.EntityFramework.Contexts;
using Ds.Full.Domain.Contexts.Abstractions;
using Ds.Full.MySql.Entities.Finances;
using Ds.Full.MySql.Entities.Inventories;
using Ds.Full.MySql.Entities.Medias;
using Ds.Full.MySql.Entities.Persons;
using Ds.Full.MySql.Entities.Rentals;
using Ds.Full.MySql.Entities.Staffs;
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
        modelBuilder.ApplyConfiguration<CategoryEntity>(new CategoryMap());
        modelBuilder.ApplyConfiguration<InventoryEntity>(new InventoryMap());
        modelBuilder.ApplyConfiguration<PaymentEntity>(new PaymentMap());
        modelBuilder.ApplyConfiguration<PersonEntity>(new PersonMap());
        modelBuilder.ApplyConfiguration<PersonContactEntity>(new PersonContactMap());
        modelBuilder.ApplyConfiguration<PersonAddressEntity>(new PersonAddressMap());
        modelBuilder.ApplyConfiguration<ProfileEntity>(new ProfileMap());
        modelBuilder.ApplyConfiguration<RentalEntity>(new RentalMap());
        modelBuilder.ApplyConfiguration<RentalItemEntity>(new RentalItemMap());
        modelBuilder.ApplyConfiguration<TitleEntity>(new TitleMap());
        modelBuilder.ApplyConfiguration<UserEntity>(new UserMap());
    }

}

