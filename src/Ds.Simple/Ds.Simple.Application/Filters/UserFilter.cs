using Ds.Base.Domain.Filters;
using Ds.Base.Domain.Filters.Abstractions;

namespace Ds.Simple.Application.Filters;

public class UserFilter : Filter, IFilter
{

    public int? ProfileId { get; set; }
    public string? UserName { get; set; }
    public bool? IsActive { get; set; }
    public string? ProfileCode { get; set; }

}
