using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.Domain.Models;
using Ds.Full.Domain.Models.Rentals;
using Ds.Full.WebApi.Results.Inventories;
using IResult = Ds.Base.Domain.Results.Abstractions.IResult;

namespace Ds.Full.WebApi.Results.Rentals;

public class RentalItemResult : IdentifiableLong, IResult, IMapFrom<RentalItemResult, RentalItem>
{

    public long RentalId { get; set; } = 0;
    public long InventoryId { get; set; } = 0;
    public RentalResult? Rental { get; set; }
    public InventoryResult? Inventory { get; set; }

    public RentalItemResult() { }
    public RentalItemResult(RentalItem model) => MapFrom(model);

    public static RentalItemResult MapFrom(RentalItem? model) => model is null ? new() : new()
    {
        Id = model.Id,
        RentalId = model.RentalId,
        InventoryId = model.InventoryId,
    };

    public static RentalItemResult MapFrom(RentalItem? model, string[]? include) => model is null ? new() : new()
    {
        Id = model.Id,
        RentalId = model.RentalId,
        InventoryId = model.InventoryId,

        Rental = (include?.Any(a => a.Equals("Rental")) ?? false) && model.Rental != null
            ? RentalResult.MapFrom(model.Rental, include) : null,
        Inventory = (include?.Any(a => a.Equals("Inventory")) ?? false) && model.Inventory != null
            ? InventoryResult.MapFrom(model.Inventory, include) : null,
    };

}
