using Ds.Base.Domain.Filters;
using Ds.Base.Domain.Filters.Abstractions;

namespace Ds.Simple.Application.Filters;

public class ProfileFilter : Filter, IFilter
{

    public string? Code { get; set; }
    public string? Description { get; set; }

}
