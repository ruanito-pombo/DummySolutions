using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.Domain.Models;
using Ds.Full.Domain.Enums.Persons;
using Ds.Full.Domain.Models.Persons;
using IResult = Ds.Base.Domain.Results.Abstractions.IResult;

namespace Ds.Full.WebApi.Results.Persons;

public class PersonContactResult : IdentifiableLong, IResult, IMapFrom<PersonContactResult, PersonContact>
{

    public long PersonId { get; set; } = 0;
    public ContactType ContactType { get; set; } = ContactType.Unknown;
    public string Contact { get; set; } = string.Empty;
    public PersonResult? Person { get; set; }

    public PersonContactResult() { }
    public PersonContactResult(PersonContact model) => MapFrom(model);

    public static PersonContactResult MapFrom(PersonContact? model) => model is null ? new() : new()
    {
        Id = model.Id,
        PersonId = model.PersonId,
        ContactType = model.ContactType,
        Contact = model.Contact,
    };

    public static PersonContactResult MapFrom(PersonContact? model, string[]? include) => model is null ? new() : new()
    {
        Id = model.Id,
        PersonId = model.PersonId,
        ContactType = model.ContactType,
        Contact = model.Contact,

        Person = (include?.Any(a => a.Equals("Person")) ?? false) && model.Person != null
            ? PersonResult.MapFrom(model.Person, include) : null,
    };

}
