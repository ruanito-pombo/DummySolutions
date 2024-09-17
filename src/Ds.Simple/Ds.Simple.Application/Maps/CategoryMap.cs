using Ds.Base.EntityFramework.Utils;
using Ds.Simple.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Ds.Simple.Application.Constants.DsSimpleConstant;

namespace Ds.Simple.Application.Maps;

public class CategoryMap : IEntityTypeConfiguration<CategoryEntity>
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
