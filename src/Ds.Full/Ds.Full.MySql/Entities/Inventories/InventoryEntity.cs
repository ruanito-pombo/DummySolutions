using Ds.Base.Domain.Entities.Abstractions;
using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.EntityFramework.Entities;
using Ds.Full.Domain.Enums.Inventories;
using Ds.Full.Domain.Models.Inventories;
using Ds.Full.MySql.Entities.Medias;
using Ds.Full.MySql.Entities.Persons;
using Ds.Full.MySql.Entities.Rentals;

namespace Ds.Full.MySql.Entities.Inventories;

public class InventoryEntity : AuditableEntityLong, IEntity, IMap<InventoryEntity, Inventory>
{

    public long TitleId { get; set; } = 0;
    public long SupplierId { get; set; } = 0;
    public DateTime AcquisitionDate { get; set; } = DateTime.MinValue;
    public decimal AcquisitionValue { get; set; } = 0;
    public InventoryStatus Status { get; set; } = InventoryStatus.Unknown;
    public DateTime? SellingDate { get; set; }
    public decimal? SellingValue { get; set; }
    public TitleEntity? Title { get; set; }
    public PersonEntity? Supplier { get; set; }
    public List<RentalItemEntity>? RentalItemList { get; set; }

    public InventoryEntity() { }
    public InventoryEntity(Inventory model) => MapFrom(model);

    public static InventoryEntity MapFrom(Inventory? model) => model is null ? new() : new()
    {
        Id = model.Id,
        CreateDate = model.CreateDate,
        UpdateDate = model.UpdateDate,
        TitleId = model.TitleId,
        SupplierId = model.SupplierId,
        AcquisitionDate = model.AcquisitionDate,
        AcquisitionValue = model.AcquisitionValue,
        Status = model.Status,
        SellingDate = model.SellingDate,
        SellingValue = model.SellingValue,
    };

    public static InventoryEntity MapFrom(Inventory? model, string[]? include) => model is null ? new() : new()
    {
        Id = model.Id,
        CreateDate = model.CreateDate,
        UpdateDate = model.UpdateDate,
        TitleId = model.TitleId,
        SupplierId = model.SupplierId,
        AcquisitionDate = model.AcquisitionDate,
        AcquisitionValue = model.AcquisitionValue,
        Status = model.Status,
        SellingDate = model.SellingDate,
        SellingValue = model.SellingValue,

        Title = (include?.Any(a => a.Equals("Title")) ?? false) && model.Title != null
            ? TitleEntity.MapFrom(model.Title, include) : null,
        Supplier = (include?.Any(a => a.Equals("Supplier")) ?? false) && model.Supplier != null
            ? PersonEntity.MapFrom(model.Supplier, include) : null,

        RentalItemList = (include?.Any(a => a.Equals("RentalItemList")) ?? false) && model.RentalItemList != null
            ? model.RentalItemList.Select(s => RentalItemEntity.MapFrom(s, include))?.ToList() : null,
    };

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
