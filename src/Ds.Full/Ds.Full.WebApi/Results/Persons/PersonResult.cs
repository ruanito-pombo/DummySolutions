using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.Domain.Models;
using Ds.Full.Domain.Enums.Persons;
using Ds.Full.Domain.Models.Persons;
using Ds.Full.WebApi.Results.Finances;
using Ds.Full.WebApi.Results.Inventories;
using Ds.Full.WebApi.Results.Medias;
using Ds.Full.WebApi.Results.Rentals;
using Ds.Full.WebApi.Results.Staffs;
using IResult = Ds.Base.Domain.Results.Abstractions.IResult;

namespace Ds.Full.WebApi.Results.Persons;

public class PersonResult : AuditableLong, IResult, IMapFrom<PersonResult, Person>
{

    public int? UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; } = DateTime.MinValue;
    public PersonType PersonType { get; set; } = PersonType.Unknown;
    public UserResult? User { get; set; }
    public List<PersonContactResult>? PersonContactList { get; set; }
    public List<PersonAddressResult>? PersonAddressList { get; set; }
    public List<TitleResult>? TitleAuthorList { get; set; }
    public List<TitleResult>? TitleProducerList { get; set; }
    public List<InventoryResult>? InventorySupplierList { get; set; }
    public List<RentalResult>? RentalCustomerList { get; set; }
    public List<PaymentResult>? PaymentCustomerList { get; set; }

    public PersonResult() { }
    public PersonResult(Person model) => MapFrom(model);

    public static PersonResult MapFrom(Person? model) => model is null ? new() : new()
    {
        Id = model.Id,
        CreateDate = model.CreateDate,
        UpdateDate = model.UpdateDate,
        UserId = model.UserId,
        FullName = model.FullName,
        BirthDate = model.BirthDate,
        PersonType = model.PersonType,

        User = model.User != null ? UserResult.MapFrom(model.User) : null,

        PersonContactList = model.PersonContactList?.Select(PersonContactResult.MapFrom)?.ToList(),
        PersonAddressList = model.PersonAddressList?.Select(PersonAddressResult.MapFrom)?.ToList(),
    };

    public static PersonResult MapFrom(Person? model, string[]? include) => model is null ? new() : new()
    {
        Id = model.Id,
        CreateDate = model.CreateDate,
        UpdateDate = model.UpdateDate,
        UserId = model.UserId,
        FullName = model.FullName,
        BirthDate = model.BirthDate,
        PersonType = model.PersonType,

        User = (include?.Any(a => a.Equals("User")) ?? false) && model.User != null
            ? model.User != null ? UserResult.MapFrom(model.User) : null : null,

        PersonContactList = (include?.Any(a => a.Equals("PersonContactList")) ?? false) && model.PersonContactList != null
            ? model.PersonContactList.Select(s => PersonContactResult.MapFrom(s, include))?.ToList() : null,
        PersonAddressList = (include?.Any(a => a.Equals("PersonAddressList")) ?? false) && model.PersonAddressList != null
            ? model.PersonAddressList.Select(s => PersonAddressResult.MapFrom(s, include))?.ToList() : null,
        TitleAuthorList = (include?.Any(a => a.Equals("TitleAuthorList")) ?? false) && model.TitleAuthorList != null
            ? model.TitleAuthorList.Select(s => TitleResult.MapFrom(s, include))?.ToList() : null,
        TitleProducerList = (include?.Any(a => a.Equals("TitleProducerList")) ?? false) && model.TitleProducerList != null
            ? model.TitleProducerList.Select(s => TitleResult.MapFrom(s, include))?.ToList() : null,
        RentalCustomerList = (include?.Any(a => a.Equals("RentalCustomerList")) ?? false) && model.RentalCustomerList != null
            ? model.RentalCustomerList.Select(s => RentalResult.MapFrom(s, include))?.ToList() : null,
        PaymentCustomerList = (include?.Any(a => a.Equals("PaymentCustomerList")) ?? false) && model.PaymentCustomerList != null
            ? model.PaymentCustomerList.Select(s => PaymentResult.MapFrom(s, include))?.ToList() : null,
    };

}
