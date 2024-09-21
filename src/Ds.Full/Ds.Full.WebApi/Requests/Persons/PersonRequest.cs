using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.Domain.Requests.Abstractions;
using Ds.Base.WebApi.Requests;
using Ds.Full.Domain.Enums.Persons;
using Ds.Full.Domain.Models.Persons;
using Ds.Full.WebApi.Requests.Finances;
using Ds.Full.WebApi.Requests.Inventories;
using Ds.Full.WebApi.Requests.Medias;
using Ds.Full.WebApi.Requests.Rentals;
using Ds.Full.WebApi.Requests.Staffs;

namespace Ds.Full.WebApi.Requests.Persons;

public class PersonRequest : AuditableRequestLong, IRequest, IMapTo<Person>
{

    public int? UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; } = DateTime.MinValue;
    public PersonType PersonType { get; set; } = PersonType.Unknown;
    public UserRequest? User { get; set; }
    public List<PersonContactRequest>? PersonContactList { get; set; }
    public List<PersonAddressRequest>? PersonAddressList { get; set; }
    public List<TitleRequest>? TitleAuthorList { get; set; }
    public List<TitleRequest>? TitleProducerList { get; set; }
    public List<InventoryRequest>? InventorySupplierList { get; set; }
    public List<RentalRequest>? RentalCustomerList { get; set; }
    public List<PaymentRequest>? PaymentCustomerList { get; set; }

    public Person MapTo() => new()
    {
        Id = Id,
        CreateDate = CreateDate,
        UpdateDate = UpdateDate,
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
        CreateDate = CreateDate,
        UpdateDate = UpdateDate,
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
