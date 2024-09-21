using Ds.Base.EntityFramework.Maps;
using Ds.Full.MySql.Entities.Rentals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ds.Full.MySql.Maps.Rentals;

public class RentalItemMap : IdentifiableMapLong<RentalItemEntity>
{

    public override void Configure(EntityTypeBuilder<RentalItemEntity> builder)
    {
        base.Configure(builder, GetType().Name.Replace("Map", ""));

        builder.Property(p => p.Id)
            .HasColumnOrder(1)
            .HasColumnType("BIGINT")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasKey(pk => pk.Id)
            .HasName("PK_RentalItem_Id");

        builder.Property(p => p.RentalId)
            .HasColumnType("BIGINT");

        builder.Property(p => p.InventoryId)
            .HasColumnType("BIGINT");

        builder.HasOne(s => s.Rental)
            .WithMany(d => d.RentalItemList)
            .HasForeignKey(s => s.RentalId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Rental_TO_RentalItem_ON_RentalId");

        builder.HasOne(s => s.Inventory)
            .WithMany(d => d.RentalItemList)
            .HasForeignKey(s => s.InventoryId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("DK_Inventory_TO_RentalItem_ON_InventoryId");

        //builder.HasData(DbSetUtil.LoadEmbeddedJson<RentalItemEntity>(SolutionName, TableName));
    }

}
