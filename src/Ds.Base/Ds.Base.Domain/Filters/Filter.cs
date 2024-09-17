using Ds.Base.Domain.Filters.Abstractions;

namespace Ds.Base.Domain.Filters;

public class Filter : IFilter
{

    public int PageSize { get; set; } = 0;
    public int PageIndex { get; set; } = 0;

}
