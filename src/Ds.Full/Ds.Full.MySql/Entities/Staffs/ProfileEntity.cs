using Ds.Base.Domain.Entities.Abstractions;
using Ds.Base.Domain.Maping.Abstractions;
using Ds.Base.EntityFramework.Entities;
using Ds.Full.Domain.Models.Staffs;

namespace Ds.Full.MySql.Entities.Staffs;

public class ProfileEntity : IdentifiableEntityInt, IEntity, IMap<ProfileEntity, Profile>
{

    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<UserEntity>? UserList { get; set; }

    public ProfileEntity() { }
    public ProfileEntity(Profile model) => MapFrom(model);

    public static ProfileEntity MapFrom(Profile? model) => model is null ? new() : new()
    {
        Id = model.Id,
        Code = model.Code,
        Description = model.Description,
    };

    public static ProfileEntity MapFrom(Profile? model, string[]? include) => model is null ? new() : new()
    {
        Id = model.Id,
        Code = model.Code,
        Description = model.Description,

        UserList = (include?.Any(a => a.Equals("UserList")) ?? false) && model.UserList != null
            ? model.UserList.Select(s => UserEntity.MapFrom(s, include))?.ToList() : null,
    };

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