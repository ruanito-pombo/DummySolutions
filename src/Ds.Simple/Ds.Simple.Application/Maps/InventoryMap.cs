using Ds.Base.Mockup.Utils;
using Ds.Simple.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Ds.Simple.Application.Constants.DsSimpleConstant;

namespace Ds.Simple.Application.Maps;

public class InventoryMap : IEntityTypeConfiguration<InventoryEntity>
{

    public void Configure(EntityTypeBuilder<InventoryEntity> builder)
    {
        var table = GetType().Name.Replace("Map", "");

        builder.ToTable(name: table);

        builder.Property(p => p.Id)
            .HasColumnOrder(1)
            .HasColumnType("BIGINT")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasKey(pk => pk.Id)
            .HasName("PK_Inventory_Id");

        builder.Property(p => p.TitleId)
            .HasColumnType("BIGINT");

        builder.Property(p => p.SupplierId)
            .HasColumnType("BIGINT");

        builder.Property(p => p.AcquisitionDate)
            .HasColumnType("DATETIME");

        builder.Property(p => p.AcquisitionValue)
            .HasColumnType("DECIMAL(18,2)");
        
        builder.Property(p => p.Status)
            .HasColumnType("TINYINT");

        builder.Property(p => p.SellingDate)
            .HasColumnType("DATETIME");

        builder.Property(p => p.SellingValue)
            .HasColumnType("DECIMAL(18,2)");

        builder.HasOne(s => s.Title)
            .WithMany(d => d.InventoryList)
            .HasForeignKey(s => s.TitleId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Title_TO_Inventory_ON_TitleId");

        builder.HasOne(s => s.Supplier)
            .WithMany(d => d.InventorySupplierList)
            .HasForeignKey(s => s.SupplierId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Person_TO_Inventory_ON_SupplierId");

        builder.HasData(DbSetUtil.LoadEmbeddedJson<InventoryEntity>(SolutionName, table));
    }

}
