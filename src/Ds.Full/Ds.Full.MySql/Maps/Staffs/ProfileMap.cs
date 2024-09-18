using Ds.Base.EntityFramework.Maps;
using Ds.Base.EntityFramework.Utils;
using Ds.Full.MySql.Entities.Staffs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Ds.Full.Domain.Constants.DsFullConstant;

namespace Ds.Full.MySql.Maps.Staffs;

public class ProfileMap : IdentifiableIntMap, IEntityTypeConfiguration<ProfileEntity>
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
