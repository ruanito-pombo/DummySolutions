using Ds.Base.EntityFramework.Maps;
using Ds.Full.MySql.Entities.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ds.Full.MySql.Maps.Persons;

public class PersonAddressMap : IdentifiableMapLong<PersonAddressEntity>
{

    public override void Configure(EntityTypeBuilder<PersonAddressEntity> builder)
    {
        base.Configure(builder, GetType().Name.Replace("Map", ""));

        builder.Property(p => p.PersonId)
            .HasColumnType("BIGINT");

        builder.Property(p => p.AddressType)
            .HasColumnType("SMALLINT");

        builder.Property(p => p.Address)
            .HasColumnType("VARCHAR(128)");

        builder.HasOne(s => s.Person)
            .WithMany(d => d.PersonAddressList)
            .HasForeignKey(s => s.PersonId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Person_TO_PersonAddress_ON_PersonId");

        //builder.HasData(DbSetUtil.LoadEmbeddedJson<PersonAddressEntity>(SolutionName, TableName));
    }

}
