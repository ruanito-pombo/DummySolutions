using Ds.Base.Domain.Filters;
using Ds.Base.Domain.Filters.Abstractions;

namespace Ds.Full.Domain.Filters.Staffs;

public class UserFilter : Filter, IFilter
{

    public int? ProfileId { get; set; }
    public string? UserName { get; set; }
    public int? PersonId { get; set; }
    public string? PersonName { get; set; }
    public string? PersonContact { get; set; }
    public string? PersonAddress { get; set; }

}
