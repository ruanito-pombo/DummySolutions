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

        builder.HasMany(p => p.TitleAuthorList)
            .WithOne(t => t.Author)
            .HasForeignKey(t => t.AuthorId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Person_TO_Title_ON_AuthorId");

        builder.HasMany(p => p.TitleProducerList)
            .WithOne(t => t.Producer)
            .HasForeignKey(t => t.ProducerId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Person_TO_Title_ON_ProducerId");

        //builder.HasData(DbSetUtil.LoadEmbeddedJson<PersonEntity>(SolutionName, TableName));
    }

}
