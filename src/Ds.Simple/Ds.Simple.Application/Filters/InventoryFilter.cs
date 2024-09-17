using Ds.Base.Core.Filters.Abstractions;
using Ds.Base.Core.Filters;

namespace Ds.Simple.Application.Filters;

public class InventoryFilter : Filter, IFilter
{

    public string? TitleName { get; set; }
    public string? SupplierName { get; set; }
    public DateTime? AcquisitionDate { get; set; }

}
