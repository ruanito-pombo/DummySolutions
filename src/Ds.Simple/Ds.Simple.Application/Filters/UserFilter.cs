using Ds.Base.Core.Filters;
using Ds.Base.Core.Filters.Abstractions;

namespace Ds.Simple.Application.Filters;

public class UserFilter : Filter, IFilter
{

    public int? ProfileId { get; set; }
    public string? UserName { get; set; }
    public bool? IsActive { get; set; }
    public string? ProfileCode { get; set; }

}
