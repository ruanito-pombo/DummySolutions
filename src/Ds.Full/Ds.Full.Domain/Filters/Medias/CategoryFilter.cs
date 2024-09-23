using Ds.Base.Domain.Filters;
using Ds.Base.Domain.Filters.Abstractions;

namespace Ds.Full.Domain.Filters.Medias;

public class CategoryFilter : Filter, IFilter
{

    public string? Description { get; set; }

}
