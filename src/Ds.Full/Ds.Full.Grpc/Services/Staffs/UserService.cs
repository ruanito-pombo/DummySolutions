using Ds.Full.Domain.Businesses.Abstractions.Staffs;
using Ds.Full.Grpc.Mappers.Staffs;
using Ds.Full.Grpc.Services.Abstractions.Staffs;
using Ds.Full.Proto.Protos;
using Ds.Full.Proto.Protos.Staffs;
using Grpc.Core;

namespace Ds.Full.Grpc.Services.Staffs;

public class UserService(IUserBusiness userBusiness) : UserSrv.UserSrvBase, IUserService
{

    private readonly IUserBusiness _userBusiness = userBusiness;

    public async override Task<UserMsg> GetUser(AuditableIntMsg request, ServerCallContext context)
    {
        var model = await _userBusiness.Get(request.Id);
        var result = model?.MapTo() ?? new();
        return result;
    }
    public async override Task<UserListMsg> FilterUser(UserFilterMsg request, ServerCallContext context)
    {
        var model = await _userBusiness.Filter(request.MapTo());
        var result = new UserListMsg(); result.List.AddRange(model?.Select(s => s.MapTo()));
        return result;
    }
    public async override Task<UserListMsg> ListUser(UserFilterMsg request, ServerCallContext context)
    {
        var model = await _userBusiness.Filter(request.MapTo());
        var result = new UserListMsg(); result.List.AddRange(model?.Select(s => s.MapTo()));
        return result;
    }

    public async override Task<UserMsg> CreateUser(UserMsg request, ServerCallContext context)
    {
        var model = await _userBusiness.Save(request.MapTo());
        var result = model.MapTo();
        return result;
    }
    public async override Task<UserMsg> DeleteUser(AuditableIntMsg request, ServerCallContext context)
    {
        var model = await _userBusiness.Delete(request.Id);
        var result = model.MapTo();
        return result;
    }

    public async override Task<UserMsg> UpdateUser(UserMsg request, ServerCallContext context)
    {
        var model = await _userBusiness.Save(request.MapTo());
        var result = model.MapTo();
        return result;
    }

}
