using Ds.Base.Domain.Models.Abstractions;
using Ds.Simple.Application.Enums;

namespace Ds.Simple.Application.Models;

public class Inventory : IModel
{

    public long Id { get; set; } = 0;
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
