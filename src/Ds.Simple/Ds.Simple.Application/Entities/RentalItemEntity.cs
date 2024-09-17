using Ds.Base.Core.Entities.Abstractions;
using Ds.Base.Core.Maping.Abstractions;
using Ds.Simple.Application.Models;

namespace Ds.Simple.Application.Entities;

public class RentalItemEntity : IEntity, IMap<RentalItemEntity, RentalItem>
{

    public long Id { get; set; } = 0;
    public long RentalId { get; set; } = 0;
    public long InventoryId { get; set; } = 0;
    public RentalEntity? Rental { get; set; }
    public InventoryEntity? Inventory { get; set; }

    public RentalItemEntity() { }
    public RentalItemEntity(RentalItem model) => MapFrom(model);

    public static RentalItemEntity MapFrom(RentalItem? model) => model is null ? new() : new()
    {
        Id = model.Id,
        RentalId = model.RentalId,
        InventoryId = model.InventoryId,
    };

    public static RentalItemEntity MapFrom(RentalItem? model, string[]? include) => model is null ? new() : new()
    {
        Id = model.Id,
        RentalId = model.RentalId,
        InventoryId = model.InventoryId,

        Rental = (include?.Any(a => a.Equals("Rental")) ?? false) && model.Rental != null
            ? RentalEntity.MapFrom(model.Rental, include) : null,
        Inventory = (include?.Any(a => a.Equals("Inventory")) ?? false) && model.Inventory != null
            ? InventoryEntity.MapFrom(model.Inventory, include) : null,
    };

    public RentalItem MapTo() => new()
    {
        Id = Id,
        RentalId = RentalId,
        InventoryId = InventoryId,

        Rental = Rental?.MapTo(),
        Inventory = Inventory?.MapTo()
    };

    public RentalItem MapTo(string[]? except) => new()
    {
        Id = Id,
        RentalId = RentalId,
        InventoryId = InventoryId,

        Rental = !(except?.Any(a => a.Equals("Rental")) ?? false)
            ? Rental?.MapTo(except) : null,
        Inventory = !(except?.Any(a => a.Equals("Inventory")) ?? false)
            ? Inventory?.MapTo(except) : null,
    };

}
