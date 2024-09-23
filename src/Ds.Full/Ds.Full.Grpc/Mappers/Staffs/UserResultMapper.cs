using Ds.Full.Domain.Models.Staffs;
using Ds.Full.Proto.Protos.Staffs;
using static Ds.Base.Grpc.Mappers.ResultMapper;

namespace Ds.Full.Grpc.Mappers.Staffs;

public static class UserResultMapper
{

    public static User MapFromModel(this UserMsg message) => new()
    {
        Id = message.Auditable.Id,
        CreateDate = ToDateTimeOffset(message.Auditable.CreateDate),
        UpdateDate = ToDateTimeOffset(message.Auditable.UpdateDate),
        UserName = message.UserName,
    };

    public static UserMsg MapFromMessage(this User model) => new()
    {
        Auditable = new()
        {
            Id = model.Id,
            CreateDate = ToDateTimeOffsetMsg(model.CreateDate),
            UpdateDate = ToDateTimeOffsetMsg(model.UpdateDate),
        },
        UserName = model.UserName,
    };

}
