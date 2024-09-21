using Ds.Base.Domain.Filters.Abstractions;

namespace Ds.Base.Domain.Filters;

public class Filter : IFilter
{
    public int? PageSize { get; set; }
    public int? PageIndex { get; set; }

}
