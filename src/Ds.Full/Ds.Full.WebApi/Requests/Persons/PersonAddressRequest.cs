using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.Domain.Requests.Abstractions;
using Ds.Base.WebApi.Requests;
using Ds.Full.Domain.Enums.Persons;
using Ds.Full.Domain.Models.Persons;

namespace Ds.Full.WebApi.Requests.Persons;

public class PersonAddressRequest : IdentifiableRequestLong, IRequest, IMapTo<PersonAddress>
{

    public long PersonId { get; set; } = 0;
    public AddressType AddressType { get; set; } = AddressType.Unknown;
    public string Address { get; set; } = string.Empty;
    public PersonRequest? Person { get; set; }

    public PersonAddress MapTo() => new()
    {
        Id = Id,
        PersonId = PersonId,
        AddressType = AddressType,
        Address = Address,
    };

    public PersonAddress MapTo(string[]? except) => new()
    {
        Id = Id,
        PersonId = PersonId,
        AddressType = AddressType,
        Address = Address,

        Person = !(except?.Any(a => a.Equals("Person")) ?? false)
            ? Person?.MapTo(except) : null,
    };

}
