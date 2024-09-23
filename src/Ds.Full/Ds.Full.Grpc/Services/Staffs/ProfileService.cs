using Ds.Full.Grpc.Mappers.Staffs;
using Ds.Full.Grpc.Services.Abstractions.Staffs;
using Ds.Full.Proto.Protos;
using Ds.Full.Proto.Protos.Staffs;
using Grpc.Core;

namespace Ds.Full.Grpc.Services.Staffs;

public class ProfileService(/*IProfileBusiness userBusiness*/) : ProfileSrv.ProfileSrvBase, IProfileService
{

    /*private readonly IProfileBusiness _userBusiness = userBusiness;*/

    public override Task<ProfileMsg> GetProfile(AuditableIntMsg request, ServerCallContext context)
    {
        //return base.GetProfile(request, context);

        return Task.Run(() => new ProfileMsg());
    }

    public override Task<ProfileListMsg> FilterProfile(ProfileFilterMsg request, ServerCallContext context)
    {
        var a = request.MapToModel();

        return Task.Run(() => new ProfileListMsg());
    }

    public override Task<ProfileListMsg> ListProfile(EmptyMsg request, ServerCallContext context)
    {
        return Task.Run(() => new ProfileListMsg());
    }

    public override Task<ProfileMsg> CreateProfile(ProfileMsg request, ServerCallContext context)
    {
        //var a = request.MapToModel();

        return base.CreateProfile(request, context);
    }

    public override Task<ProfileMsg> UpdateProfile(ProfileMsg request, ServerCallContext context)
    {
        return base.UpdateProfile(request, context);
    }

    public override Task<ProfileMsg> DeleteProfile(AuditableIntMsg request, ServerCallContext context)
    {
        return base.DeleteProfile(request, context);
    }

}
