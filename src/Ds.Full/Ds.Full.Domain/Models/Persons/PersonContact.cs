using Ds.Base.Domain.Models;
using Ds.Base.Domain.Models.Abstractions;
using Ds.Full.Domain.Enums.Persons;

namespace Ds.Full.Domain.Models.Persons;

public class PersonContact : IdentifiableLong, IModel
{

    public long PersonId { get; set; } = 0;
    public ContactType ContactType { get; set; } = ContactType.Unknown;
    public string Contact { get; set; } = string.Empty;
    public Person? Person { get; set; }

}
