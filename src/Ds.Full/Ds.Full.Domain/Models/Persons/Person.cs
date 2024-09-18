using Ds.Base.Domain.Models;
using Ds.Base.Domain.Models.Abstractions;
using Ds.Full.Domain.Enums.Persons;
using Ds.Full.Domain.Models.Finances;
using Ds.Full.Domain.Models.Inventories;
using Ds.Full.Domain.Models.Medias;
using Ds.Full.Domain.Models.Rentals;
using Ds.Full.Domain.Models.Staffs;

namespace Ds.Full.Domain.Models.Persons;

public class Person : AuditableLong, IModel
{

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
