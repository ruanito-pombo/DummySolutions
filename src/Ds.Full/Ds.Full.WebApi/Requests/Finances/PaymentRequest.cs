using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.Domain.Requests.Abstractions;
using Ds.Base.WebApi.Requests;
using Ds.Full.Domain.Models.Finances;
using Ds.Full.WebApi.Requests.Persons;
using Ds.Full.WebApi.Requests.Rentals;

namespace Ds.Full.WebApi.Requests.Finances;

public class PaymentRequest : AuditableRequestLong, IRequest, IMapTo<Payment>
{

    public long RentalId { get; set; } = 0;
    public long CustomerId { get; set; } = 0;
    public DateTime PaymentDate { get; set; } = DateTime.MinValue;
    public decimal RentalFee { get; set; } = 0;
    public decimal? OtherFee { get; set; }
    public decimal? OverdueFee { get; set; }
    public decimal? RewindFee { get; set; }
    public RentalRequest? Rental { get; set; }
    public PersonRequest? Customer { get; set; }

    public Payment MapTo() => new()
    {
        Id = Id,
        CreateDate = CreateDate,
        UpdateDate = UpdateDate,
        RentalId = RentalId,
        CustomerId = CustomerId,
        PaymentDate = PaymentDate,
        RentalFee = RentalFee,
        OtherFee = OtherFee,
        OverdueFee = OverdueFee,
        RewindFee = RewindFee,

        Rental = Rental?.MapTo(),
        Customer = Customer?.MapTo(),
    };

    public Payment MapTo(string[]? except) => new()
    {
        Id = Id,
        CreateDate = CreateDate,
        UpdateDate = UpdateDate,
        RentalId = RentalId,
        CustomerId = CustomerId,
        PaymentDate = PaymentDate,
        RentalFee = RentalFee,
        OtherFee = OtherFee,
        OverdueFee = OverdueFee,
        RewindFee = RewindFee,

        Rental = !(except?.Any(a => a.Equals("Rental")) ?? false)
            ? Rental?.MapTo(except) : null,
        Customer = !(except?.Any(a => a.Equals("Customer")) ?? false)
            ? Customer?.MapTo(except) : null,
    };

}
