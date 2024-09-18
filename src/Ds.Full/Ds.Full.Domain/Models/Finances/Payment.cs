using Ds.Base.Domain.Models;
using Ds.Base.Domain.Models.Abstractions;
using Ds.Full.Domain.Models.Persons;
using Ds.Full.Domain.Models.Rentals;

namespace Ds.Full.Domain.Models.Finances;

public class Payment : AuditableLong, IModel
{

    public long RentalId { get; set; } = 0;
    public long CustomerId { get; set; } = 0;
    public DateTime PaymentDate { get; set; } = DateTime.MinValue;
    public decimal RentalFee { get; set; } = 0;
    public decimal? OtherFee { get; set; }
    public decimal? OverdueFee { get; set; }
    public decimal? RewindFee { get; set; }
    public Rental? Rental { get; set; }
    public Person? Customer { get; set; }

}
