using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.Domain.Models;
using Ds.Full.Domain.Models.Staffs;
using Ds.Full.WebApi.Results.Persons;
using Ds.Full.WebApi.Results.Rentals;
using IResult = Ds.Base.Domain.Results.Abstractions.IResult;

namespace Ds.Full.WebApi.Results.Staffs;

public class UserResult : AuditableInt, IResult, IMapFrom<UserResult, User>
{

    public int ProfileId { get; set; } = 0;
    public long? PersonId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public ProfileResult? Profile { get; set; }
    public PersonResult? Person { get; set; }
    public List<RentalResult>? RentalList { get; set; }

    public UserResult() { }
    public UserResult(User model) => MapFrom(model);

    public static UserResult MapFrom(User? model) => model is null ? new() : new()
    {
        Id = model.Id,
        CreateDate = model.CreateDate,
        UpdateDate = model.UpdateDate,
        ProfileId = model.ProfileId,
        PersonId = model.PersonId,
        UserName = model.UserName,
        IsActive = model.IsActive,
    };

    public static UserResult MapFrom(User? model, string[]? include) => model is null ? new() : new()
    {
        Id = model.Id,
        CreateDate = model.CreateDate,
        UpdateDate = model.UpdateDate,
        ProfileId = model.ProfileId,
        PersonId = model.PersonId,
        UserName = model.UserName,
        IsActive = model.IsActive,

        Profile = (include?.Any(a => a.Equals("Profile")) ?? false) && model.Profile != null
            ? ProfileResult.MapFrom(model.Profile, include) : null,
        Person = (include?.Any(a => a.Equals("Person")) ?? false) && model.Person != null
            ? PersonResult.MapFrom(model.Person, include) : null,

        RentalList = (include?.Any(a => a.Equals("RentalList")) ?? false) && model.RentalList != null
            ? model.RentalList.Select(s => RentalResult.MapFrom(s, include))?.ToList() : null,
    };

}
