using Ds.Base.Domain.Filters;
using Ds.Base.Domain.Filters.Abstractions;

namespace Ds.Simple.Application.Filters;

public class PaymentFilter : Filter, IFilter
{

    public long? CustomerId { get; set; }
    public string? CustomerName { get; set; }

}
