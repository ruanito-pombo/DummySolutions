using Ds.Base.EntityFramework.Utils;
using Ds.Simple.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Ds.Simple.Application.Constants.DsSimpleConstant;

namespace Ds.Simple.Application.Maps;

public class PaymentMap : IEntityTypeConfiguration<PaymentEntity>
{

    public void Configure(EntityTypeBuilder<PaymentEntity> builder)
    {
        var table = GetType().Name.Replace("Map", "");

        builder.ToTable(name: table);

        builder.Property(p => p.Id)
            .HasColumnOrder(1)
            .HasColumnType("BIGINT")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasKey(pk => pk.Id)
            .HasName("PK_Payment_Id");

        builder.Property(p => p.RentalId)
            .HasColumnType("BIGINT");

        builder.Property(p => p.CustomerId)
            .HasColumnType("BIGINT");

        builder.Property(p => p.PaymentDate)
            .HasColumnType("DATETIME");

        builder.Property(p => p.RentalFee)
            .HasColumnType("DECIMAL(18,2)");

        builder.Property(p => p.OtherFee)
            .HasColumnType("DECIMAL(18,2)");

        builder.Property(p => p.OverdueFee)
            .HasColumnType("DECIMAL(18,2)");

        builder.Property(p => p.RewindFee)
            .HasColumnType("DECIMAL(18,2)");

        builder.HasOne(s => s.Rental)
            .WithOne(d => d.Payment)
            .HasForeignKey<RentalEntity>(s => s.PaymentId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Rental_TO_Payment_ON_PaymentId");

        builder.HasOne(s => s.Customer)
            .WithMany(d => d.PaymentCustomerList)
            .HasForeignKey(s => s.CustomerId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Person_TO_Payment_ON_CustomerId");

        builder.HasData(DbSetUtil.LoadEmbeddedJson<PaymentEntity>(SolutionName, table));
    }

}
