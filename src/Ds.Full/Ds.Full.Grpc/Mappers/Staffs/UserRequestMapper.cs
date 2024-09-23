using Ds.Full.Domain.Models.Staffs;
using Ds.Full.Proto.Protos.Staffs;
using static Ds.Base.Grpc.Mappers.RequestMapper;

namespace Ds.Full.Grpc.Mappers.Staffs;

public static class UserRequestMapper
{

    public static User MapToModel(this UserMsg message) => new()
    {
        Id = message.Auditable.Id,
        CreateDate = ToDateTimeOffset(message.Auditable.CreateDate),
        UpdateDate = ToDateTimeOffset(message.Auditable.UpdateDate),
        UserName = message.UserName,

    };

    public static UserMsg MapToMessage(this User model) => new()
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
