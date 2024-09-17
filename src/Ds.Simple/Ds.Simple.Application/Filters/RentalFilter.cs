using Ds.Base.Core.Filters.Abstractions;
using Ds.Base.Core.Filters;

namespace Ds.Simple.Application.Filters;

public class RentalFilter : Filter, IFilter
{

    public int? UserId { get; set; }
    public string? CustomerName { get; set; }

}
