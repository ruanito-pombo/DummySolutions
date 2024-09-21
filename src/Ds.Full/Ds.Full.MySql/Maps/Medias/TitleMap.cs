using Ds.Base.EntityFramework.Maps;
using Ds.Full.MySql.Entities.Medias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ds.Full.MySql.Maps.Medias;

public class TitleMap : AuditableMapLong<TitleEntity>
{

    public override void Configure(EntityTypeBuilder<TitleEntity> builder)
    {
        base.Configure(builder, GetType().Name.Replace("Map", ""));

        builder.Property(p => p.Id)
            .HasColumnOrder(1)
            .HasColumnType("INT")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasKey(pk => pk.Id)
            .HasName("PK_Title_Id");

        builder.Property(p => p.CategoryId)
            .HasColumnType("INT");

        builder.Property(p => p.AuthorId)
            .HasColumnType("BIGINT");

        builder.Property(p => p.ProducerId)
            .HasColumnType("BIGINT");

        builder.Property(p => p.FullName)
            .HasColumnType("VARCHAR(256)");

        builder.Property(p => p.ReleaseDate)
            .HasColumnType("DATETIME");

        builder.Property(p => p.MediaType)
            .HasColumnType("TINYINT");

        builder.Property(p => p.ContentType)
            .HasColumnType("TINYINT");

        builder.Property(p => p.Rating)
            .HasColumnType("TINYINT");

        builder.HasOne(s => s.Author)
            .WithMany(d => d.TitleAuthorList)
            .HasForeignKey(s => s.AuthorId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Person_TO_Title_ON_AuthorId");

        builder.HasOne(s => s.Producer)
            .WithMany(d => d.TitleProducerList)
            .HasForeignKey(s => s.ProducerId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Person_TO_Title_ON_ProducerId");

        builder.HasOne(s => s.Category)
            .WithMany(d => d.TitleList)
            .HasForeignKey(s => s.CategoryId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Category_TO_Title_ON_CategoryId");

        //builder.HasData(DbSetUtil.LoadEmbeddedJson<TitleEntity>(SolutionName, TableName));
    }

}
