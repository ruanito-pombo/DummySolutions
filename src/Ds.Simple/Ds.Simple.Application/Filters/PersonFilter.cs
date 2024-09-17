using Ds.Base.Domain.Filters;
using Ds.Base.Domain.Filters.Abstractions;
using Ds.Simple.Application.Enums;

namespace Ds.Simple.Application.Filters;

public class PersonFilter : Filter, IFilter
{

    public long? Id { get; set; }
    public string? FullName { get; set; }
    public DateTime? BirthDate { get; set; }
    public ContactType? ContactType { get; set; }
    public string? Contact { get; set; }
    public AddressType? AddressType { get; set; }
    public string? Address { get; set; }


}
