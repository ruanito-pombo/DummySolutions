using Ds.Base.EntityFramework.Utils;
using Ds.Simple.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Ds.Simple.Application.Constants.DsSimpleConstant;

namespace Ds.Simple.Application.Maps;

public class PersonMap : IEntityTypeConfiguration<PersonEntity>
{

    public void Configure(EntityTypeBuilder<PersonEntity> builder)
    {
        var table = GetType().Name.Replace("Map", "");

        builder.ToTable(name: table);

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

        builder.HasData(DbSetUtil.LoadEmbeddedJson<PersonEntity>(SolutionName, table));
    }

}
