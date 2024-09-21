using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.Domain.Requests.Abstractions;
using Ds.Base.WebApi.Requests;
using Ds.Full.Domain.Models.Staffs;
using Ds.Full.WebApi.Requests.Persons;
using Ds.Full.WebApi.Requests.Rentals;

namespace Ds.Full.WebApi.Requests.Staffs;

public class UserRequest : AuditableRequestInt, IRequest, IMapTo<User>
{

    public int ProfileId { get; set; } = 0;
    public long? PersonId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public ProfileRequest? Profile { get; set; }
    public PersonRequest? Person { get; set; }
    public List<RentalRequest>? RentalList { get; set; }

    public User MapTo() => new()
    {
        Id = Id,
        CreateDate = CreateDate,
        UpdateDate = UpdateDate,
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
        CreateDate = CreateDate,
        UpdateDate = UpdateDate,
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
