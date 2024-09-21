using Ds.Base.EntityFramework.Maps;
using Ds.Full.MySql.Entities.Medias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ds.Full.MySql.Maps.Medias;

public class CategoryMap : IdentifiableMapInt<CategoryEntity>
{

    public override void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        base.Configure(builder, GetType().Name.Replace("Map", ""));

        builder.Property(p => p.Id)
            .HasColumnOrder(1)
            .HasColumnType("INT")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasKey(pk => pk.Id)
            .HasName("PK_Category_Id");

        builder.Property(p => p.Description)
            .HasColumnType("VARCHAR(256)");

        builder.Property(p => p.Rating)
            .HasColumnType("TINYINT");

        //builder.HasData(DbSetUtil.LoadEmbeddedJson<CategoryEntity>(SolutionName, TableName));
    }

}
