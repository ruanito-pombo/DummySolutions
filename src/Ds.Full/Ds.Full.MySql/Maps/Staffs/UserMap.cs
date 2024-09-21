using Ds.Base.EntityFramework.Maps;
using Ds.Full.MySql.Entities.Persons;
using Ds.Full.MySql.Entities.Staffs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ds.Full.MySql.Maps.Staffs;

public class UserMap : AuditableMapInt<UserEntity>
{

    public override void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        base.Configure(builder, GetType().Name.Replace("Map", ""));

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

        //builder.HasData(DbSetUtil.LoadEmbeddedJson<UserEntity>(SolutionName, TableName));
    }

}
