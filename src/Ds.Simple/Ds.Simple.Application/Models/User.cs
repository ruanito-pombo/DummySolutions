using Ds.Base.Domain.Models.Abstractions;

namespace Ds.Simple.Application.Models;

public class User : IModel
{

    public int Id { get; set; } = 0;
    public int ProfileId { get; set; } = 0;
    public long? PersonId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public Profile? Profile { get; set; }
    public Person? Person { get; set; }
    public List<Rental>? RentalList { get; set; }

}
