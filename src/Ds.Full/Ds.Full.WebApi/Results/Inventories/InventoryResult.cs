using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.Domain.Models;
using Ds.Full.Domain.Enums.Inventories;
using Ds.Full.Domain.Models.Inventories;
using Ds.Full.WebApi.Results.Medias;
using Ds.Full.WebApi.Results.Persons;
using Ds.Full.WebApi.Results.Rentals;
using IResult = Ds.Base.Domain.Results.Abstractions.IResult;

namespace Ds.Full.WebApi.Results.Inventories;

public class InventoryResult : AuditableLong, IResult, IMapFrom<InventoryResult, Inventory>
{

    public long TitleId { get; set; } = 0;
    public long SupplierId { get; set; } = 0;
    public DateTime AcquisitionDate { get; set; } = DateTime.MinValue;
    public decimal AcquisitionValue { get; set; } = 0;
    public InventoryStatus Status { get; set; } = InventoryStatus.Unknown;
    public DateTime? SellingDate { get; set; }
    public decimal? SellingValue { get; set; }
    public TitleResult? Title { get; set; }
    public PersonResult? Supplier { get; set; }
    public List<RentalItemResult>? RentalItemList { get; set; }

    public InventoryResult() { }
    public InventoryResult(Inventory model) => MapFrom(model);

    public static InventoryResult MapFrom(Inventory? model) => model is null ? new() : new()
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

    public static InventoryResult MapFrom(Inventory? model, string[]? include) => model is null ? new() : new()
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
            ? TitleResult.MapFrom(model.Title, include) : null,
        Supplier = (include?.Any(a => a.Equals("Supplier")) ?? false) && model.Supplier != null
            ? PersonResult.MapFrom(model.Supplier, include) : null,

        RentalItemList = (include?.Any(a => a.Equals("RentalItemList")) ?? false) && model.RentalItemList != null
            ? model.RentalItemList.Select(s => RentalItemResult.MapFrom(s, include))?.ToList() : null,
    };

}
