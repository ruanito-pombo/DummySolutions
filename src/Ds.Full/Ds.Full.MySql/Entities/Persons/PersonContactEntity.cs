﻿using Ds.Base.Domain.Entities.Abstractions;
using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.EntityFramework.Entities;
using Ds.Full.Domain.Enums.Persons;
using Ds.Full.Domain.Models.Persons;

namespace Ds.Full.MySql.Entities.Persons;

public class PersonContactEntity : IdentifiableEntityLong, IEntity, IMap<PersonContactEntity, PersonContact>
{

    public long PersonId { get; set; } = 0;
    public ContactType ContactType { get; set; } = ContactType.Unknown;
    public string Contact { get; set; } = string.Empty;
    public PersonEntity? Person { get; set; }

    public PersonContactEntity() { }
    public PersonContactEntity(PersonContact model) => MapFrom(model);

    public static PersonContactEntity MapFrom(PersonContact? model) => model is null ? new() : new()
    {
        Id = model.Id,
        PersonId = model.PersonId,
        ContactType = model.ContactType,
        Contact = model.Contact,
    };

    public static PersonContactEntity MapFrom(PersonContact? model, string[]? include) => model is null ? new() : new()
    {
        Id = model.Id,
        PersonId = model.PersonId,
        ContactType = model.ContactType,
        Contact = model.Contact,

        Person = (include?.Any(a => a.Equals("Person")) ?? false) && model.Person != null
            ? PersonEntity.MapFrom(model.Person, include) : null,
    };

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
