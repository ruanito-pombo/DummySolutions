using Ds.Base.Domain.Filters;
using Ds.Base.Domain.Filters.Abstractions;

namespace Ds.Full.Domain.Filters.Staffs;

public class UserFilter : Filter, IFilter
{

    public int? UserId { get; set; }
    public int? ProfileId { get; set; }
    public string? UserName { get; set; }
    public bool? IsActive { get; set; }
    public string? ProfileCode { get; set; }

}
