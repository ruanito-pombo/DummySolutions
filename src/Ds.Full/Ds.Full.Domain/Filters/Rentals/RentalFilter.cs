using Ds.Base.Domain.Filters;
using Ds.Base.Domain.Filters.Abstractions;

namespace Ds.Full.Domain.Filters.Rentals;

public class RentalFilter : Filter, IFilter
{

    public int? UserId { get; set; }
    public string? CustomerName { get; set; }

}
