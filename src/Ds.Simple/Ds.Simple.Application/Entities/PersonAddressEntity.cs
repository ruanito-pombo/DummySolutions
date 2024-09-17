using Ds.Base.Core.Entities.Abstractions;
using Ds.Base.Core.Maping.Abstractions;
using Ds.Simple.Application.Enums;
using Ds.Simple.Application.Models;

namespace Ds.Simple.Application.Entities;

public class PersonAddressEntity : IEntity, IMap<PersonAddressEntity, PersonAddress>
{

    public long Id { get; set; } = 0;
    public long PersonId { get; set; } = 0;
    public AddressType AddressType { get; set; } = AddressType.Unknown;
    public string Address { get; set; } = string.Empty;
    public PersonEntity? Person { get; set; }

    public PersonAddressEntity() { }
    public PersonAddressEntity(PersonAddress model) => MapFrom(model);

    public static PersonAddressEntity MapFrom(PersonAddress? model) => model is null ? new() : new()
    {
        Id = model.Id,
        PersonId = model.PersonId,
        AddressType = model.AddressType,
        Address = model.Address,
    };

    public static PersonAddressEntity MapFrom(PersonAddress? model, string[]? include) => model is null ? new() : new()
    {
        Id = model.Id,
        PersonId = model.PersonId,
        AddressType = model.AddressType,
        Address = model.Address,

        Person = (include?.Any(a => a.Equals("Person")) ?? false) && model.Person != null
            ? PersonEntity.MapFrom(model.Person, include) : null,
    };

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
