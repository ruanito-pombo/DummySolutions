using Ds.Base.Core.Filters.Abstractions;
using Ds.Base.Core.Filters;

namespace Ds.Simple.Application.Filters;

public class PaymentFilter : Filter, IFilter
{

    public long? CustomerId { get; set; }
    public string? CustomerName { get; set; }

}
