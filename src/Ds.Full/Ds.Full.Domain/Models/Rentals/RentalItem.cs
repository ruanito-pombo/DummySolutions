using Ds.Base.Domain.Models;
using Ds.Base.Domain.Models.Abstractions;
using Ds.Full.Domain.Models.Inventories;

namespace Ds.Full.Domain.Models.Rentals;

public class RentalItem : IdentifiableLong, IModel
{

    public long RentalId { get; set; } = 0;
    public long InventoryId { get; set; } = 0;
    public Rental? Rental { get; set; }
    public Inventory? Inventory { get; set; }

}
