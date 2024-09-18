using Ds.Base.Domain.Models;
using Ds.Base.Domain.Models.Abstractions;
using Ds.Full.Domain.Enums.Inventories;
using Ds.Full.Domain.Models.Medias;
using Ds.Full.Domain.Models.Persons;
using Ds.Full.Domain.Models.Rentals;

namespace Ds.Full.Domain.Models.Inventories;

public class Inventory : AuditableLong, IModel
{

    public long TitleId { get; set; } = 0;
    public long SupplierId { get; set; } = 0;
    public DateTime AcquisitionDate { get; set; } = DateTime.MinValue;
    public decimal AcquisitionValue { get; set; } = 0;
    public InventoryStatus Status { get; set; } = InventoryStatus.Unknown;
    public DateTime? SellingDate { get; set; }
    public decimal? SellingValue { get; set; }
    public Title? Title { get; set; }
    public Person? Supplier { get; set; }
    public List<RentalItem>? RentalItemList { get; set; }

}
