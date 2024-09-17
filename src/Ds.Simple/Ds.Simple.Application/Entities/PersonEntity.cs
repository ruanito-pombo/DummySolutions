using Ds.Base.Core.Entities.Abstractions;
using Ds.Base.Core.Maping.Abstractions;
using Ds.Simple.Application.Enums;
using Ds.Simple.Application.Models;

namespace Ds.Simple.Application.Entities;

public class PersonEntity : IEntity, IMap<PersonEntity, Person>
{

    public long Id { get; set; } = 0;
    public int? UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; } = DateTime.MinValue;
    public PersonType PersonType { get; set; } = PersonType.Unknown;
    public UserEntity? User { get; set; }
    public List<PersonContactEntity>? PersonContactList { get; set; }
    public List<PersonAddressEntity>? PersonAddressList { get; set; }
    public List<TitleEntity>? TitleAuthorList { get; set; }
    public List<TitleEntity>? TitleProducerList { get; set; }
    public List<InventoryEntity>? InventorySupplierList { get; set; }
    public List<RentalEntity>? RentalCustomerList { get; set; }
    public List<PaymentEntity>? PaymentCustomerList { get; set; }

    public PersonEntity() { }
    public PersonEntity(Person model) => MapFrom(model);

    public static PersonEntity MapFrom(Person? model) => model is null ? new() : new()
    {
        Id = model.Id,
        UserId = model.UserId,
        FullName = model.FullName,
        BirthDate = model.BirthDate,
        PersonType = model.PersonType,

        User = model.User != null ? UserEntity.MapFrom(model.User) : null,

        PersonContactList = model.PersonContactList?.Select(PersonContactEntity.MapFrom)?.ToList(),
        PersonAddressList = model.PersonAddressList?.Select(PersonAddressEntity.MapFrom)?.ToList(),
    };

    public static PersonEntity MapFrom(Person? model, string[]? include) => model is null ? new() : new()
    {
        Id = model.Id,
        UserId = model.UserId,
        FullName = model.FullName,
        BirthDate = model.BirthDate,
        PersonType = model.PersonType,

        User = (include?.Any(a => a.Equals("User")) ?? false) && model.User != null
            ? model.User != null ? UserEntity.MapFrom(model.User) : null : null,

        PersonContactList = (include?.Any(a => a.Equals("PersonContactList")) ?? false) && model.PersonContactList != null
            ? model.PersonContactList.Select(s => PersonContactEntity.MapFrom(s, include))?.ToList() : null,
        PersonAddressList = (include?.Any(a => a.Equals("PersonAddressList")) ?? false) && model.PersonAddressList != null
            ? model.PersonAddressList.Select(s => PersonAddressEntity.MapFrom(s, include))?.ToList() : null,
        TitleAuthorList = (include?.Any(a => a.Equals("TitleAuthorList")) ?? false) && model.TitleAuthorList != null
            ? model.TitleAuthorList.Select(s => TitleEntity.MapFrom(s, include))?.ToList() : null,
        TitleProducerList = (include?.Any(a => a.Equals("TitleProducerList")) ?? false) && model.TitleProducerList != null
            ? model.TitleProducerList.Select(s => TitleEntity.MapFrom(s, include))?.ToList() : null,
        RentalCustomerList = (include?.Any(a => a.Equals("RentalCustomerList")) ?? false) && model.RentalCustomerList != null
            ? model.RentalCustomerList.Select(s => RentalEntity.MapFrom(s, include))?.ToList() : null,
        PaymentCustomerList = (include?.Any(a => a.Equals("PaymentCustomerList")) ?? false) && model.PaymentCustomerList != null
            ? model.PaymentCustomerList.Select(s => PaymentEntity.MapFrom(s, include))?.ToList() : null,
    };

    public Person MapTo() => new()
    {
        Id = Id,
        UserId = UserId,
        FullName = FullName,
        BirthDate = BirthDate,
        PersonType = PersonType,

        User = User?.MapTo(),

        PersonContactList = PersonContactList?.Select(s => s.MapTo())?.ToList(),
        PersonAddressList = PersonAddressList?.Select(s => s.MapTo())?.ToList(),
        TitleAuthorList = TitleAuthorList?.Select(s => s.MapTo())?.ToList(),
        TitleProducerList = TitleProducerList?.Select(s => s.MapTo())?.ToList(),
        InventorySupplierList = InventorySupplierList?.Select(s => s.MapTo())?.ToList(),
        RentalCustomerList = RentalCustomerList?.Select(s => s.MapTo())?.ToList(),
        PaymentCustomerList = PaymentCustomerList?.Select(s => s.MapTo())?.ToList(),
    };

    public Person MapTo(string[]? except) => new()
    {
        Id = Id,
        UserId = UserId,
        FullName = FullName,
        BirthDate = BirthDate,
        PersonType = PersonType,

        User = !(except?.Any(a => a.Equals("User")) ?? false)
            ? User?.MapTo(except) : null,

        PersonContactList = !(except?.Any(a => a.Equals("PersonContactList")) ?? false)
            ? PersonContactList?.Select(s => s.MapTo(except))?.ToList() : null,
        PersonAddressList = !(except?.Any(a => a.Equals("PersonAddressList")) ?? false)
            ? PersonAddressList?.Select(s => s.MapTo(except))?.ToList() : null,
        TitleAuthorList = !(except?.Any(a => a.Equals("TitleAuthorList")) ?? false)
            ? TitleAuthorList?.Select(s => s.MapTo(except))?.ToList() : null,
        TitleProducerList = !(except?.Any(a => a.Equals("TitleProducerList")) ?? false)
            ? TitleProducerList?.Select(s => s.MapTo(except))?.ToList() : null,
        InventorySupplierList = !(except?.Any(a => a.Equals("InventorySupplierList")) ?? false)
            ? InventorySupplierList?.Select(s => s.MapTo(except))?.ToList() : null,
        RentalCustomerList = !(except?.Any(a => a.Equals("RentalCustomerList")) ?? false)
            ? RentalCustomerList?.Select(s => s.MapTo(except))?.ToList() : null,
        PaymentCustomerList = !(except?.Any(a => a.Equals("PaymentCustomerList")) ?? false)
            ? PaymentCustomerList?.Select(s => s.MapTo(except))?.ToList() : null,
    };

}
