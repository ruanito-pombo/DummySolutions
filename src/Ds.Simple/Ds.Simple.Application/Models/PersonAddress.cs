using Ds.Base.Domain.Models.Abstractions;
using Ds.Simple.Application.Enums;

namespace Ds.Simple.Application.Models;
public class PersonAddress : IModel
{

    public long Id { get; set; } = 0;
    public long PersonId { get; set; } = 0;
    public AddressType AddressType { get; set; } = AddressType.Unknown;
    public string Address { get; set; } = string.Empty;
    public Person? Person { get; set; }

}
