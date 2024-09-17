using Ds.Base.Core.Models.Abstractions;
using Ds.Simple.Application.Enums;

namespace Ds.Simple.Application.Models;

public class Person : IModel
{

    public long Id { get; set; } = 0;
    public int? UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; } = DateTime.MinValue;
    public PersonType PersonType { get; set; } = PersonType.Unknown;
    public User? User { get; set; }
    public List<PersonContact>? PersonContactList { get; set; }
    public List<PersonAddress>? PersonAddressList { get; set; }
    public List<Title>? TitleAuthorList { get; set; }
    public List<Title>? TitleProducerList { get; set; }
    public List<Inventory>? InventorySupplierList { get; set; }
    public List<Rental>? RentalCustomerList { get; set; }
    public List<Payment>? PaymentCustomerList { get; set; }

}
