using Ds.Base.EntityFramework.Maps;
using Ds.Full.MySql.Entities.Persons;
using Ds.Full.MySql.Entities.Staffs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ds.Full.MySql.Maps.Persons;

public class PersonMap : AuditableMapLong<PersonEntity>
{

    public override void Configure(EntityTypeBuilder<PersonEntity> builder)
    {
        base.Configure(builder, GetType().Name.Replace("Map", ""));

        builder.Property(p => p.Id)
            .HasColumnOrder(1)
            .HasColumnType("BIGINT")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasKey(pk => pk.Id)
            .HasName("PK_Person_Id");

        builder.Property(p => p.UserId)
            .HasColumnType("INT");

        builder.Property(p => p.FullName)
            .HasColumnType("VARCHAR(256)");

        builder.Property(p => p.BirthDate)
            .HasColumnType("DATETIME");

        builder.Property(p => p.PersonType)
            .HasColumnType("INT");

        builder.HasOne(s => s.User)
            .WithOne(d => d.Person)
            .HasForeignKey<UserEntity>(s => s.PersonId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_User_TO_Person_ON_PersonId");

        //builder.HasData(DbSetUtil.LoadEmbeddedJson<PersonEntity>(SolutionName, TableName));
    }

}
