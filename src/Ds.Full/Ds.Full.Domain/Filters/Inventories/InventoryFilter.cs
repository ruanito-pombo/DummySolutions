using Ds.Base.Domain.Filters;
using Ds.Base.Domain.Filters.Abstractions;

namespace Ds.Full.Domain.Filters.Inventories;

public class InventoryFilter : Filter, IFilter
{

    public string? TitleName { get; set; }
    public string? SupplierName { get; set; }
    public DateTime? AcquisitionDate { get; set; }

}
