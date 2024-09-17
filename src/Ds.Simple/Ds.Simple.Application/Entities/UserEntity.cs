using Ds.Base.Domain.Entities.Abstractions;
using Ds.Base.Domain.Maping.Abstractions;
using Ds.Simple.Application.Models;

namespace Ds.Simple.Application.Entities;

public class UserEntity : IEntity, IMap<UserEntity, User>
{

    public int Id { get; set; } = 0;
    public int ProfileId { get; set; } = 0;
    public long? PersonId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public ProfileEntity? Profile { get; set; }
    public PersonEntity? Person { get; set; }
    public List<RentalEntity>? RentalList { get; set; }

    public UserEntity() { }
    public UserEntity(User model) => MapFrom(model);

    public static UserEntity MapFrom(User? model) => model is null ? new() : new()
    {
        Id = model.Id,
        ProfileId = model.ProfileId,
        PersonId = model.PersonId,
        UserName = model.UserName,
        IsActive = model.IsActive,
    };

    public static UserEntity MapFrom(User? model, string[]? include) => model is null ? new() : new()
    {
        Id = model.Id,
        ProfileId = model.ProfileId,
        PersonId = model.PersonId,
        UserName = model.UserName,
        IsActive = model.IsActive,

        Profile = (include?.Any(a => a.Equals("Profile")) ?? false) && model.Profile != null
            ? ProfileEntity.MapFrom(model.Profile, include) : null,
        Person = (include?.Any(a => a.Equals("Person")) ?? false) && model.Person != null
            ? PersonEntity.MapFrom(model.Person, include) : null,

        RentalList = (include?.Any(a => a.Equals("RentalList")) ?? false) && model.RentalList != null
            ? model.RentalList.Select(s => RentalEntity.MapFrom(s, include))?.ToList() : null,
    };

    public User MapTo() => new()
    {
        Id = Id,
        ProfileId = ProfileId,
        PersonId = PersonId,
        UserName = UserName,
        IsActive = IsActive,

        Profile = Profile?.MapTo(),
        Person = Person?.MapTo(),

        RentalList = RentalList?.Select(s => s.MapTo())?.ToList(),
    };

    public User MapTo(string[]? except) => new()
    {
        Id = Id,
        ProfileId = ProfileId,
        PersonId = PersonId,
        UserName = UserName,
        IsActive = IsActive,

        Profile = !(except?.Any(a => a.Equals("Profile")) ?? false)
            ? Profile?.MapTo(except) : null,
        Person = !(except?.Any(a => a.Equals("Person")) ?? false)
            ? Person?.MapTo(except) : null,

        RentalList = !(except?.Any(a => a.Equals("RentalList")) ?? false)
            ? RentalList?.Select(s => s.MapTo(except))?.ToList() : null,
    };

}
