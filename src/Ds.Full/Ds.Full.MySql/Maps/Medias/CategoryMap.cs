using Ds.Base.EntityFramework.Maps;
using Ds.Base.EntityFramework.Utils;
using Ds.Full.MySql.Entities.Medias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Ds.Full.Domain.Constants.DsFullConstant;

namespace Ds.Full.MySql.Maps.Medias;

public class CategoryMap : IdentifiableIntMap, IEntityTypeConfiguration<CategoryEntity>
{

    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        var table = GetType().Name.Replace("Map", "");

        builder.ToTable(name: table);

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

        builder.HasData(DbSetUtil.LoadEmbeddedJson<CategoryEntity>(SolutionName, table));
    }

}
