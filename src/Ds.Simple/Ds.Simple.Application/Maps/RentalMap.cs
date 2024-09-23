using Ds.Base.EntityFramework.Utils;
using Ds.Simple.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Ds.Simple.Application.Constants.DsSimpleConstant;

namespace Ds.Simple.Application.Maps;

public class RentalMap : IEntityTypeConfiguration<RentalEntity>
{

    public void Configure(EntityTypeBuilder<RentalEntity> builder)
    {
        var table = GetType().Name.Replace("Map", "");

        builder.ToTable(name: table);

        builder.Property(p => p.Id)
            .HasColumnOrder(1)
            .HasColumnType("BIGINT")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasKey(pk => pk.Id)
            .HasName("PK_Rental_Id");

        builder.Property(p => p.UserId)
            .HasColumnType("INT");

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

        builder.HasData(DbSetUtil.LoadEmbeddedJson<RentalEntity>(SolutionName, table));
    }

}
