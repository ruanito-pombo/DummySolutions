using Ds.Base.EntityFramework.Maps;
using Ds.Full.MySql.Entities.Staffs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ds.Full.MySql.Maps.Staffs;

public class ProfileMap : AuditableMapInt<ProfileEntity>
{

    public override void Configure(EntityTypeBuilder<ProfileEntity> builder)
    {
        base.Configure(builder, GetType().Name.Replace("Map", ""));

        builder.Property(p => p.Code)
            .HasColumnType("VARCHAR(64)");

        builder.Property(p => p.Description)
            .HasColumnType("VARCHAR(128)");

        //builder.HasData(DbSetUtil.LoadEmbeddedJson<ProfileEntity>(SolutionName, TableName));
    }

}
