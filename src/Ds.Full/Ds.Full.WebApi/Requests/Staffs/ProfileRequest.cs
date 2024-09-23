using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.Domain.Requests.Abstractions;
using Ds.Base.WebApi.Requests;
using Ds.Full.Domain.Models.Staffs;

namespace Ds.Full.WebApi.Requests.Staffs;
public class ProfileRequest : AuditableRequestInt, IRequest, IMapTo<Profile>
{

    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<UserRequest>? UserList { get; set; }

    public Profile MapTo() => new()
    {
        Id = Id,
        Code = Code,
        Description = Description,
    };

    public Profile MapTo(string[]? except) => new()
    {
        Id = Id,
        Code = Code,
        Description = Description,

        UserList = !(except?.Any(a => a.Equals("UserList")) ?? false)
            ? UserList?.Select(s => s.MapTo(except))?.ToList() : null,
    };

}
