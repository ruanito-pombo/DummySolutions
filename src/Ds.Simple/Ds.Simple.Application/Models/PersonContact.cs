using Ds.Base.Core.Models;
using Ds.Base.Core.Models.Abstractions;
using Ds.Simple.Application.Enums;

namespace Ds.Simple.Application.Models;

public class PersonContact : IModel
{

    public long Id { get; set; } = 0;
    public long PersonId { get; set; } = 0;
    public ContactType ContactType { get; set; } = ContactType.Unknown;
    public string Contact { get; set; } = string.Empty;
    public Person? Person { get; set; }

}
