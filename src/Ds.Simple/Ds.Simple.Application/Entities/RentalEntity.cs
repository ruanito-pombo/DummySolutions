using Ds.Base.Domain.Entities.Abstractions;
using Ds.Base.Domain.Maping.Abstractions;
using Ds.Simple.Application.Enums;
using Ds.Simple.Application.Models;

namespace Ds.Simple.Application.Entities;

public class RentalEntity : IEntity, IMap<RentalEntity, Rental>
{

    public long Id { get; set; } = 0;
    public int UserId { get; set; } = 0;
    public long CustomerId { get; set; } = 0;
    public long? PaymentId { get; set; } = 0;
    public RentalStatus Status { get; set; } = RentalStatus.Unknown;
    public DateTime RentalDate { get; set; } = DateTime.MinValue;
    public DateTime? DeadlineDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public UserEntity? User { get; set; }
    public PersonEntity? Customer { get; set; }
    public PaymentEntity? Payment { get; set; }
    public List<RentalItemEntity>? RentalItemList { get; set; }

    public RentalEntity() { }
    public RentalEntity(Rental model) => MapFrom(model);

    public static RentalEntity MapFrom(Rental? model) => model is null ? new() : new()
    {
        Id = model.Id,
        UserId = model.UserId,
        CustomerId = model.CustomerId,
        PaymentId = model.PaymentId,
        Status = model.Status,
        RentalDate = model.RentalDate,
        DeadlineDate = model.DeadlineDate,
        ReturnDate = model.ReturnDate,

        RentalItemList = model.RentalItemList != null ? model.RentalItemList?.Select(RentalItemEntity.MapFrom)?.ToList() : null,
    };

    public static RentalEntity MapFrom(Rental? model, string[]? include) => model is null ? new() : new()
    {
        Id = model.Id,
        UserId = model.UserId,
        CustomerId = model.CustomerId,
        PaymentId = model.PaymentId,
        Status = model.Status,
        RentalDate = model.RentalDate,
        DeadlineDate = model.DeadlineDate,
        ReturnDate = model.ReturnDate,

        User = (include?.Any(a => a.Equals("User")) ?? false) && model.User != null
            ? UserEntity.MapFrom(model.User, include) : null,
        Customer = (include?.Any(a => a.Equals("Customer")) ?? false) && model.Customer != null
            ? PersonEntity.MapFrom(model.Customer, include) : null,
        Payment = (include?.Any(a => a.Equals("Payment")) ?? false) && model.Payment != null
            ? PaymentEntity.MapFrom(model.Payment, include) : null,

        RentalItemList = (include?.Any(a => a.Equals("RentalItemList")) ?? false) && model.RentalItemList != null
            ? model.RentalItemList.Select(s => RentalItemEntity.MapFrom(s, include))?.ToList() : null,
    };

    public Rental MapTo() => new()
    {
        Id = Id,
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
