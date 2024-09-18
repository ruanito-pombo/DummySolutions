using Ds.Base.EntityFramework.Maps;
using Ds.Base.EntityFramework.Utils;
using Ds.Full.MySql.Entities.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Ds.Full.Domain.Constants.DsFullConstant;

namespace Ds.Full.MySql.Maps.Persons;

public class PersonContactMap : IdentifiableIntMap, IEntityTypeConfiguration<PersonContactEntity>
{

    public void Configure(EntityTypeBuilder<PersonContactEntity> builder)
    {
        var table = GetType().Name.Replace("Map", "");

        builder.ToTable(name: table);

        builder.Property(p => p.Id)
            .HasColumnOrder(1)
            .HasColumnType("BIGINT")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasKey(pk => pk.Id)
            .HasName("PK_PersonContact_Id");

        builder.Property(p => p.PersonId)
            .HasColumnType("BIGINT");

        builder.Property(p => p.ContactType)
            .HasColumnType("SMALLINT");

        builder.Property(p => p.Contact)
            .HasColumnType("VARCHAR(128)");

        builder.HasOne(s => s.Person)
            .WithMany(d => d.PersonContactList)
            .HasForeignKey(s => s.PersonId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Person_TO_PersonContact_ON_PersonId");

        builder.HasData(DbSetUtil.LoadEmbeddedJson<PersonContactEntity>(SolutionName, table));
    }

}
