using Ds.Base.Mockup.Utils;
using Ds.Simple.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Ds.Simple.Application.Constants.DsSimpleConstant;

namespace Ds.Simple.Application.Maps;

public class ProfileMap : IEntityTypeConfiguration<ProfileEntity>
{

    public void Configure(EntityTypeBuilder<ProfileEntity> builder)
    {
        var table = GetType().Name.Replace("Map", "");

        builder.ToTable(name: table);

        builder.Property(p => p.Id)
            .HasColumnOrder(1)
            .HasColumnType("INT")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasKey(pk => pk.Id)
            .HasName("PK_Profile_Id");

        builder.Property(p => p.Code)
            .HasColumnType("VARCHAR(64)");

        builder.Property(p => p.Description)
            .HasColumnType("VARCHAR(128)");

        builder.HasData(DbSetUtil.LoadEmbeddedJson<ProfileEntity>(SolutionName, table));
    }

}
