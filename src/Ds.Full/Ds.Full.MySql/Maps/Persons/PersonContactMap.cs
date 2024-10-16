﻿using Ds.Base.EntityFramework.Maps;
using Ds.Full.MySql.Entities.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ds.Full.MySql.Maps.Persons;

public class PersonContactMap : IdentifiableMapLong<PersonContactEntity>
{

    public override void Configure(EntityTypeBuilder<PersonContactEntity> builder)
    {
        base.Configure(builder, GetType().Name.Replace("Map", ""));

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

        //builder.HasData(DbSetUtil.LoadEmbeddedJson<PersonContactEntity>(SolutionName, TableName));
    }

}
