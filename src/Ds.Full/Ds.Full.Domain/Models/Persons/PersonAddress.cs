using Ds.Base.Domain.Models;
using Ds.Base.Domain.Models.Abstractions;
using Ds.Full.Domain.Enums.Persons;

namespace Ds.Full.Domain.Models.Persons;

public class PersonAddress : IdentifiableLong, IModel
{

    public long PersonId { get; set; } = 0;
    public AddressType AddressType { get; set; } = AddressType.Unknown;
    public string Address { get; set; } = string.Empty;
    public Person? Person { get; set; }

}
