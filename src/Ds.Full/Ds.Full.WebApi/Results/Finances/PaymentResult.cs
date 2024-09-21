using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.Domain.Models;
using Ds.Full.Domain.Models.Finances;
using Ds.Full.WebApi.Results.Persons;
using Ds.Full.WebApi.Results.Rentals;
using IResult = Ds.Base.Domain.Results.Abstractions.IResult;

namespace Ds.Full.WebApi.Results.Finances;

public class PaymentResult : AuditableLong, IResult, IMapFrom<PaymentResult, Payment>
{

    public long RentalId { get; set; } = 0;
    public long CustomerId { get; set; } = 0;
    public DateTime PaymentDate { get; set; } = DateTime.MinValue;
    public decimal RentalFee { get; set; } = 0;
    public decimal? OtherFee { get; set; }
    public decimal? OverdueFee { get; set; }
    public decimal? RewindFee { get; set; }
    public RentalResult? Rental { get; set; }
    public PersonResult? Customer { get; set; }

    public PaymentResult() { }
    public PaymentResult(Payment model) => MapFrom(model);

    public static PaymentResult MapFrom(Payment? model) => model is null ? new() : new()
    {
        Id = model.Id,
        CreateDate = model.CreateDate,
        UpdateDate = model.UpdateDate,
        RentalId = model.RentalId,
        CustomerId = model.CustomerId,
        PaymentDate = model.PaymentDate,
        RentalFee = model.RentalFee,
        OtherFee = model.OtherFee,
        OverdueFee = model.OverdueFee,
        RewindFee = model.RewindFee,
    };

    public static PaymentResult MapFrom(Payment? model, string[]? include) => model is null ? new() : new()
    {
        Id = model.Id,
        CreateDate = model.CreateDate,
        UpdateDate = model.UpdateDate,
        RentalId = model.RentalId,
        CustomerId = model.CustomerId,
        PaymentDate = model.PaymentDate,
        RentalFee = model.RentalFee,
        OtherFee = model.OtherFee,
        OverdueFee = model.OverdueFee,
        RewindFee = model.RewindFee,

        Rental = (include?.Any(a => a.Equals("Rental")) ?? false) && model.Rental != null
            ? RentalResult.MapFrom(model.Rental, include) : null,
        Customer = (include?.Any(a => a.Equals("Customer")) ?? false) && model.Customer != null
            ? PersonResult.MapFrom(model.Customer, include) : null,
    };

}
