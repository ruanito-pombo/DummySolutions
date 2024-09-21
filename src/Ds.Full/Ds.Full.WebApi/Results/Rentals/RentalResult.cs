using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.Domain.Models;
using Ds.Full.Domain.Enums.Rentals;
using Ds.Full.Domain.Models.Rentals;
using Ds.Full.WebApi.Results.Finances;
using Ds.Full.WebApi.Results.Persons;
using Ds.Full.WebApi.Results.Staffs;
using IResult = Ds.Base.Domain.Results.Abstractions.IResult;

namespace Ds.Full.WebApi.Results.Rentals;

public class RentalResult : AuditableLong, IResult, IMapFrom<RentalResult, Rental>
{

    public int UserId { get; set; } = 0;
    public long CustomerId { get; set; } = 0;
    public long? PaymentId { get; set; } = 0;
    public RentalStatus Status { get; set; } = RentalStatus.Unknown;
    public DateTime RentalDate { get; set; } = DateTime.MinValue;
    public DateTime? DeadlineDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public UserResult? User { get; set; }
    public PersonResult? Customer { get; set; }
    public PaymentResult? Payment { get; set; }
    public List<RentalItemResult>? RentalItemList { get; set; }

    public RentalResult() { }
    public RentalResult(Rental model) => MapFrom(model);

    public static RentalResult MapFrom(Rental? model) => model is null ? new() : new()
    {
        Id = model.Id,
        CreateDate = model.CreateDate,
        UpdateDate = model.UpdateDate,
        UserId = model.UserId,
        CustomerId = model.CustomerId,
        PaymentId = model.PaymentId,
        Status = model.Status,
        RentalDate = model.RentalDate,
        DeadlineDate = model.DeadlineDate,
        ReturnDate = model.ReturnDate,

        RentalItemList = model.RentalItemList != null ? model.RentalItemList?.Select(RentalItemResult.MapFrom)?.ToList() : null,
    };

    public static RentalResult MapFrom(Rental? model, string[]? include) => model is null ? new() : new()
    {
        Id = model.Id,
        CreateDate = model.CreateDate,
        UpdateDate = model.UpdateDate,
        UserId = model.UserId,
        CustomerId = model.CustomerId,
        PaymentId = model.PaymentId,
        Status = model.Status,
        RentalDate = model.RentalDate,
        DeadlineDate = model.DeadlineDate,
        ReturnDate = model.ReturnDate,

        User = (include?.Any(a => a.Equals("User")) ?? false) && model.User != null
            ? UserResult.MapFrom(model.User, include) : null,
        Customer = (include?.Any(a => a.Equals("Customer")) ?? false) && model.Customer != null
            ? PersonResult.MapFrom(model.Customer, include) : null,
        Payment = (include?.Any(a => a.Equals("Payment")) ?? false) && model.Payment != null
            ? PaymentResult.MapFrom(model.Payment, include) : null,

        RentalItemList = (include?.Any(a => a.Equals("RentalItemList")) ?? false) && model.RentalItemList != null
            ? model.RentalItemList.Select(s => RentalItemResult.MapFrom(s, include))?.ToList() : null,
    };

}
