using Ds.Base.Core.Models.Abstractions;

namespace Ds.Simple.Application.Models;

public class Payment : IModel
{

    public long Id { get; set; } = 0;
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
