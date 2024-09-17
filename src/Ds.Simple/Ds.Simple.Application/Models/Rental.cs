using Ds.Base.Domain.Models.Abstractions;
using Ds.Simple.Application.Enums;

namespace Ds.Simple.Application.Models;

public class Rental : IModel
{

    public long Id { get; set; } = 0;
    public int UserId { get; set; } = 0;
    public long CustomerId { get; set; } = 0;
    public long? PaymentId { get; set; } = 0;
    public RentalStatus Status { get; set; } = RentalStatus.Unknown;
    public DateTime RentalDate { get; set; } = DateTime.MinValue;
    public DateTime? DeadlineDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public User? User { get; set; }
    public Person? Customer { get; set; }
    public Payment? Payment { get; set; }
    public List<RentalItem>? RentalItemList { get; set; }

}
