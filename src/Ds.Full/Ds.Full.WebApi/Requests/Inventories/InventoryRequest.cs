using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.Domain.Requests.Abstractions;
using Ds.Base.WebApi.Requests;
using Ds.Full.Domain.Enums.Inventories;
using Ds.Full.Domain.Models.Inventories;
using Ds.Full.WebApi.Requests.Medias;
using Ds.Full.WebApi.Requests.Persons;
using Ds.Full.WebApi.Requests.Rentals;

namespace Ds.Full.WebApi.Requests.Inventories;

public class InventoryRequest : AuditableRequestLong, IRequest, IMapTo<Inventory>
{

    public long TitleId { get; set; } = 0;
    public long SupplierId { get; set; } = 0;
    public DateTime AcquisitionDate { get; set; } = DateTime.MinValue;
    public decimal AcquisitionValue { get; set; } = 0;
    public InventoryStatus Status { get; set; } = InventoryStatus.Unknown;
    public DateTime? SellingDate { get; set; }
    public decimal? SellingValue { get; set; }
    public TitleRequest? Title { get; set; }
    public PersonRequest? Supplier { get; set; }
    public List<RentalItemRequest>? RentalItemList { get; set; }

    public Inventory MapTo() => new()
    {
        Id = Id,
        CreateDate = CreateDate,
        UpdateDate = UpdateDate,
        TitleId = TitleId,
        SupplierId = SupplierId,
        AcquisitionDate = AcquisitionDate,
        AcquisitionValue = AcquisitionValue,
        Status = Status,
        SellingDate = SellingDate,
        SellingValue = SellingValue,

        Title = Title?.MapTo(),
        Supplier = Supplier?.MapTo(),

        RentalItemList = RentalItemList?.Select(s => s.MapTo())?.ToList(),
    };

    public Inventory MapTo(string[]? except) => new()
    {
        Id = Id,
        CreateDate = CreateDate,
        UpdateDate = UpdateDate,
        TitleId = TitleId,
        SupplierId = SupplierId,
        AcquisitionDate = AcquisitionDate,
        AcquisitionValue = AcquisitionValue,
        Status = Status,
        SellingDate = SellingDate,
        SellingValue = SellingValue,

        Title = !(except?.Any(a => a.Equals("Title")) ?? false)
            ? Title?.MapTo(except) : null,
        Supplier = !(except?.Any(a => a.Equals("Supplier")) ?? false)
            ? Supplier?.MapTo(except) : null,

        RentalItemList = !(except?.Any(a => a.Equals("RentalItemList")) ?? false)
            ? RentalItemList?.Select(s => s.MapTo(except))?.ToList() : null,
    };

}
