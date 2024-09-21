using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.Domain.Requests.Abstractions;
using Ds.Base.WebApi.Requests;
using Ds.Full.Domain.Enums.Persons;
using Ds.Full.Domain.Models.Persons;

namespace Ds.Full.WebApi.Requests.Persons;

public class PersonContactRequest : IdentifiableRequestLong, IRequest, IMapTo<PersonContact>
{

    public long PersonId { get; set; } = 0;
    public ContactType ContactType { get; set; } = ContactType.Unknown;
    public string Contact { get; set; } = string.Empty;
    public PersonRequest? Person { get; set; }

    public PersonContact MapTo() => new()
    {
        Id = Id,
        PersonId = PersonId,
        ContactType = ContactType,
        Contact = Contact,
    };

    public PersonContact MapTo(string[]? except) => new()
    {
        Id = Id,
        PersonId = PersonId,
        ContactType = ContactType,
        Contact = Contact,

        Person = !(except?.Any(a => a.Equals("Person")) ?? false)
            ? Person?.MapTo(except) : null,
    };

}
