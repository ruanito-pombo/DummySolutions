using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.Domain.Requests.Abstractions;
using Ds.Base.WebApi.Requests;
using Ds.Full.Domain.Enums.Rentals;
using Ds.Full.Domain.Models.Rentals;
using Ds.Full.WebApi.Requests.Finances;
using Ds.Full.WebApi.Requests.Persons;
using Ds.Full.WebApi.Requests.Staffs;

namespace Ds.Full.WebApi.Requests.Rentals;

public class RentalRequest : AuditableRequestLong, IRequest, IMapTo<Rental>
{

    public int UserId { get; set; } = 0;
    public long CustomerId { get; set; } = 0;
    public long? PaymentId { get; set; } = 0;
    public RentalStatus Status { get; set; } = RentalStatus.Unknown;
    public DateTime RentalDate { get; set; } = DateTime.MinValue;
    public DateTime? DeadlineDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public UserRequest? User { get; set; }
    public PersonRequest? Customer { get; set; }
    public PaymentRequest? Payment { get; set; }
    public List<RentalItemRequest>? RentalItemList { get; set; }

    public Rental MapTo() => new()
    {
        Id = Id,
        CreateDate = CreateDate,
        UpdateDate = UpdateDate,
        UserId = UserId,
        CustomerId = CustomerId,
        PaymentId = PaymentId,
        Status = Status,
        RentalDate = RentalDate,
        DeadlineDate = DeadlineDate,
        ReturnDate = ReturnDate,

        User = User?.MapTo(),
        Customer = Customer?.MapTo(),
        Payment = Payment?.MapTo(),

        RentalItemList = RentalItemList?.Select(s => s.MapTo())?.ToList(),
    };

    public Rental MapTo(string[]? except) => new()
    {
        Id = Id,
        CreateDate = CreateDate,
        UpdateDate = UpdateDate,
        UserId = UserId,
        CustomerId = CustomerId,
        PaymentId = PaymentId,
        Status = Status,
        RentalDate = RentalDate,
        DeadlineDate = DeadlineDate,
        ReturnDate = ReturnDate,

        User = !(except?.Any(a => a.Equals("User")) ?? false)
            ? User?.MapTo(except) : null,
        Customer = !(except?.Any(a => a.Equals("Customer")) ?? false)
            ? Customer?.MapTo(except) : null,
        Payment = !(except?.Any(a => a.Equals("Payment")) ?? false)
            ? Payment?.MapTo(except) : null,

        RentalItemList = !(except?.Any(a => a.Equals("RentalItemList")) ?? false)
            ? RentalItemList?.Select(s => s.MapTo(except))?.ToList() : null,
    };

}
