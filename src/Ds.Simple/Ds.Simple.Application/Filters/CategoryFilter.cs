using Ds.Base.Domain.Filters;
using Ds.Base.Domain.Filters.Abstractions;

namespace Ds.Simple.Application.Filters;

public class CategoryFilter : Filter, IFilter
{

    public string? Description { get; set; }

}