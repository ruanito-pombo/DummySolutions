using Ds.Base.Mockup.Utils;
using Ds.Simple.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Ds.Simple.Application.Constants.DsSimpleConstant;

namespace Ds.Simple.Application.Maps;

public class RentalItemMap : IEntityTypeConfiguration<RentalItemEntity>
{

    public void Configure(EntityTypeBuilder<RentalItemEntity> builder)
    {
        var table = GetType().Name.Replace("Map", "");

        builder.ToTable(name: table);

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

        builder.HasData(DbSetUtil.LoadEmbeddedJson<RentalItemEntity>(SolutionName, table));
    }

}
