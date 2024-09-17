using Ds.Base.Domain.Filters;
using Ds.Base.Domain.Filters.Abstractions;

namespace Ds.Simple.Application.Filters;

public class InventoryFilter : Filter, IFilter
{

    public string? TitleName { get; set; }
    public string? SupplierName { get; set; }
    public DateTime? AcquisitionDate { get; set; }

}
