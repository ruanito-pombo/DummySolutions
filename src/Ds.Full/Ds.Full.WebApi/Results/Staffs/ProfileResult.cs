using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.Domain.Models;
using Ds.Full.Domain.Models.Staffs;
using IResult = Ds.Base.Domain.Results.Abstractions.IResult;

namespace Ds.Full.WebApi.Results.Staffs;
public class ProfileResult : AuditableInt, IResult, IMapFrom<ProfileResult, Profile>
{

    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<UserResult>? UserList { get; set; }

    public ProfileResult() { }
    public ProfileResult(Profile model) => MapFrom(model);

    public static ProfileResult MapFrom(Profile? model) => model is null ? new() : new()
    {
        Id = model.Id,
        Code = model.Code,
        Description = model.Description,
    };

    public static ProfileResult MapFrom(Profile? model, string[]? include) => model is null ? new() : new()
    {
        Id = model.Id,
        Code = model.Code,
        Description = model.Description,

        UserList = (include?.Any(a => a.Equals("UserList")) ?? false) && model.UserList != null
            ? model.UserList.Select(s => UserResult.MapFrom(s, include))?.ToList() : null,
    };

}
