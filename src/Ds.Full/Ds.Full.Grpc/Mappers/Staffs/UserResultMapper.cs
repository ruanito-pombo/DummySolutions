using Ds.Full.Domain.Models.Staffs;
using Ds.Full.Proto.Protos.Staffs;

namespace Ds.Full.Grpc.Mappers.Staffs;

public static class UserResultMapper
{

    public static User MapFromModel(this UserMsg message) => new()
    {
        Id = message.Id,
        UserName = message.UserName,
    };

    public static UserMsg MapFromMessage(this User model) => new()
    {
        Id = model.Id,
        UserName = model.UserName,
    };

}
