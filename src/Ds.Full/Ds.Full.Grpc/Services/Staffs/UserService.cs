using Ds.Full.Grpc.Mappers.Staffs;
using Ds.Full.Grpc.Services.Abstractions.Staffs;
using Ds.Full.Proto.Protos;
using Ds.Full.Proto.Protos.Staffs;
using Grpc.Core;

namespace Ds.Full.Grpc.Services.Staffs;

public class UserService(/*IUserBusiness userBusiness*/) : UserSrv.UserSrvBase, IUserService
{

    /*private readonly IUserBusiness _userBusiness = userBusiness;*/

    public override Task<UserMsg> GetUser(AuditableIntMsg request, ServerCallContext context)
    {
        //return base.GetUser(request, context);

        return Task.Run(() => new UserMsg());
    }

    public override Task<UserListMsg> FilterUser(UserFilterMsg request, ServerCallContext context)
    {
        var a = request.MapToModel();

        return Task.Run(() => new UserListMsg());
    }

    public override Task<UserListMsg> ListUser(EmptyMsg request, ServerCallContext context)
    {
        return base.ListUser(request, context);
    }

    public override Task<UserMsg> CreateUser(UserMsg request, ServerCallContext context)
    {
        var a = request.MapToModel();

        return base.CreateUser(request, context);
    }

    public override Task<UserMsg> UpdateUser(UserMsg request, ServerCallContext context)
    {
        return base.UpdateUser(request, context);
    }

    public override Task<UserMsg> DeleteUser(AuditableIntMsg request, ServerCallContext context)
    {
        return base.DeleteUser(request, context);
    }

}
