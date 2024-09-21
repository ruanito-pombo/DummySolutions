using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.Domain.Models;
using Ds.Full.Domain.Enums.Persons;
using Ds.Full.Domain.Models.Persons;
using IResult = Ds.Base.Domain.Results.Abstractions.IResult;

namespace Ds.Full.WebApi.Results.Persons;

public class PersonAddressResult : IdentifiableLong, IResult, IMapFrom<PersonAddressResult, PersonAddress>
{

    public long PersonId { get; set; } = 0;
    public AddressType AddressType { get; set; } = AddressType.Unknown;
    public string Address { get; set; } = string.Empty;
    public PersonResult? Person { get; set; }

    public PersonAddressResult() { }
    public PersonAddressResult(PersonAddress model) => MapFrom(model);

    public static PersonAddressResult MapFrom(PersonAddress? model) => model is null ? new() : new()
    {
        Id = model.Id,
        PersonId = model.PersonId,
        AddressType = model.AddressType,
        Address = model.Address,
    };

    public static PersonAddressResult MapFrom(PersonAddress? model, string[]? include) => model is null ? new() : new()
    {
        Id = model.Id,
        PersonId = model.PersonId,
        AddressType = model.AddressType,
        Address = model.Address,

        Person = (include?.Any(a => a.Equals("Person")) ?? false) && model.Person != null
            ? PersonResult.MapFrom(model.Person, include) : null,
    };

}
