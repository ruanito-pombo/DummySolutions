using Ds.Base.EntityFramework.Maps;
using Ds.Full.MySql.Entities.Rentals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ds.Full.MySql.Maps.Rentals;

public class RentalMap : AuditableMapLong<RentalEntity>
{

    public override void Configure(EntityTypeBuilder<RentalEntity> builder)
    {
        base.Configure(builder, GetType().Name.Replace("Map", ""));

        builder.Property(p => p.Id)
            .HasColumnOrder(1)
            .HasColumnType("BIGINT")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasKey(pk => pk.Id)
            .HasName("PK_Rental_Id");

        builder.Property(p => p.UserId)
            .HasColumnType("BIGINT");

        builder.Property(p => p.CustomerId)
            .HasColumnType("BIGINT");

        builder.Property(p => p.PaymentId)
            .HasColumnType("BIGINT");

        builder.Property(p => p.Status)
            .HasColumnType("TINYINT");

        builder.Property(p => p.RentalDate)
            .HasColumnType("DATETIME");

        builder.Property(p => p.DeadlineDate)
            .HasColumnType("DATETIME");

        builder.Property(p => p.ReturnDate)
            .HasColumnType("DATETIME");

        builder.HasOne(s => s.User)
            .WithMany(d => d.RentalList)
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_User_TO_Rental_ON_UserId");

        //builder.HasData(DbSetUtil.LoadEmbeddedJson<RentalEntity>(SolutionName, TableName));
    }

}
