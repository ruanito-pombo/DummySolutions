using Ds.Base.EntityFramework.Utils;
using Ds.Simple.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Ds.Simple.Application.Constants.DsSimpleConstant;

namespace Ds.Simple.Application.Maps;

public class UserMap : IEntityTypeConfiguration<UserEntity>
{

    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        var table = GetType().Name.Replace("Map", "");

        builder.ToTable(name: table);

        builder.Property(p => p.Id)
            .HasColumnOrder(1)
            .HasColumnType("INT")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasKey(pk => pk.Id)
            .HasName("PK_User_Id");

        builder.Property(p => p.ProfileId)
            .HasColumnType("INT");

        builder.Property(p => p.PersonId)
            .HasColumnType("BIGINT");

        builder.Property(p => p.UserName)
            .HasColumnType("VARCHAR(64)");

        builder.Property(p => p.IsActive)
            .HasColumnType("BIT");

        builder.HasOne(s => s.Profile)
            .WithMany(d => d.UserList)
            .HasForeignKey(k => k.ProfileId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Profile_TO_User_ON_ProfileId");

        builder.HasOne(s => s.Person)
            .WithOne(d => d.User)
            .HasForeignKey<PersonEntity>(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Person_TO_User_ON_UserId");

        builder.HasData(DbSetUtil.LoadEmbeddedJson<UserEntity>(SolutionName, table));
    }

}
