using Ds.Base.Core.Models.Abstractions;

namespace Ds.Simple.Application.Models;

public class RentalItem : IModel
{

    public long Id { get; set; } = 0;
    public long RentalId { get; set; } = 0;
    public long InventoryId { get; set; } = 0;
    public Rental? Rental { get; set; }
    public Inventory? Inventory { get; set; }

}
