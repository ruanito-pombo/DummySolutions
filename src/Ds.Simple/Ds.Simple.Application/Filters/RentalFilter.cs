using Ds.Base.Domain.Filters;
using Ds.Base.Domain.Filters.Abstractions;

namespace Ds.Simple.Application.Filters;

public class RentalFilter : Filter, IFilter
{

    public int? UserId { get; set; }
    public string? CustomerName { get; set; }

}
