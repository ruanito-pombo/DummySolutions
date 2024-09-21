using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.Domain.Requests.Abstractions;
using Ds.Base.WebApi.Requests;
using Ds.Full.Domain.Models.Rentals;
using Ds.Full.WebApi.Requests.Inventories;

namespace Ds.Full.WebApi.Requests.Rentals;

public class RentalItemRequest : IdentifiableRequestLong, IRequest, IMapTo<RentalItem>
{

    public long RentalId { get; set; } = 0;
    public long InventoryId { get; set; } = 0;
    public RentalRequest? Rental { get; set; }
    public InventoryRequest? Inventory { get; set; }

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
