using Ds.Base.Domain.Models;
using Ds.Base.Domain.Models.Abstractions;
using Ds.Full.Domain.Models.Persons;
using Ds.Full.Domain.Models.Rentals;

namespace Ds.Full.Domain.Models.Staffs;

public class User : AuditableInt, IModel
{

    public int ProfileId { get; set; } = 0;
    public long? PersonId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public Profile? Profile { get; set; }
    public Person? Person { get; set; }
    public List<Rental>? RentalList { get; set; }

}
