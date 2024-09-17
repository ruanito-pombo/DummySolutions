using Ds.Base.Domain.Models;
using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Services;
using Ds.Simple.Application.Businesses.Abstractions;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;
using Ds.Simple.Application.Services.Abstractions;

namespace Ds.Simple.Application.Services;

public class InventoryService(IInventoryBusiness inventoryBusiness)
    : IdentifiableService<IdentifiableLong, long>(inventoryBusiness), IInventoryService
{

    private readonly IInventoryBusiness _inventoryBusiness = inventoryBusiness;

    public Inventory? Get(long id) =>
        _inventoryBusiness.Get(id);

    public PaginatedList<Inventory>? List(InventoryFilter filter) =>
        _inventoryBusiness.List(filter);

    public List<Inventory>? Filter(InventoryFilter filter) =>
        _inventoryBusiness.Filter(filter);

    public Inventory Save(Inventory model) =>
        _inventoryBusiness.Save(model);

    public Inventory Delete(long id) =>
        _inventoryBusiness.Delete(id);

}
