using Ds.Base.EntityFramework.Maps;
using Ds.Full.MySql.Entities.Finances;
using Ds.Full.MySql.Entities.Rentals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ds.Full.MySql.Maps.Finances;

public class PaymentMap : AuditableMapLong<PaymentEntity>
{

    public override void Configure(EntityTypeBuilder<PaymentEntity> builder)
    {
        base.Configure(builder, GetType().Name.Replace("Map", ""));

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

        //builder.HasData(DbSetUtil.LoadEmbeddedJson<PaymentEntity>(SolutionName, TableName));
    }

}
