using Ds.Base.Domain.Filters;
using Ds.Base.Domain.Filters.Abstractions;
using Ds.Full.Domain.Enums.Persons;

namespace Ds.Full.Domain.Filters.Persons;

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
