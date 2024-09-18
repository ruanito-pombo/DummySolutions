using Ds.Base.Domain.Entities.Abstractions;
using Ds.Base.Domain.Maping.Abstractions;
using Ds.Base.EntityFramework.Entities;
using Ds.Full.Domain.Models.Finances;
using Ds.Full.MySql.Entities.Persons;
using Ds.Full.MySql.Entities.Rentals;

namespace Ds.Full.MySql.Entities.Finances;

public class PaymentEntity : AuditableEntityLong, IEntity, IMap<PaymentEntity, Payment>
{

    public long RentalId { get; set; } = 0;
    public long CustomerId { get; set; } = 0;
    public DateTime PaymentDate { get; set; } = DateTime.MinValue;
    public decimal RentalFee { get; set; } = 0;
    public decimal? OtherFee { get; set; }
    public decimal? OverdueFee { get; set; }
    public decimal? RewindFee { get; set; }
    public RentalEntity? Rental { get; set; }
    public PersonEntity? Customer { get; set; }

    public PaymentEntity() { }
    public PaymentEntity(Payment model) => MapFrom(model);

    public static PaymentEntity MapFrom(Payment? model) => model is null ? new() : new()
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

    public static PaymentEntity MapFrom(Payment? model, string[]? include) => model is null ? new() : new()
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
            ? RentalEntity.MapFrom(model.Rental, include) : null,
        Customer = (include?.Any(a => a.Equals("Customer")) ?? false) && model.Customer != null
            ? PersonEntity.MapFrom(model.Customer, include) : null,
    };

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
