using Ds.Base.Core.Businesses;
using Ds.Base.Core.Models;
using Ds.Base.Core.Paginateds;
using Ds.Simple.Application.Businesses.Abstractions;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;
using Ds.Simple.Application.Repositories.Abstractions;

namespace Ds.Simple.Application.Businesses;

public class InventoryBusiness(IInventoryRepository inventoryRepository)
    : IdentifiableBusiness<IdentifiableLong, long>(inventoryRepository), IInventoryBusiness
{

    private readonly IInventoryRepository _inventoryRepository = inventoryRepository;

    public Inventory? Get(long id) =>
        _inventoryRepository.Get(id);

    public PaginatedList<Inventory>? List(InventoryFilter filter) =>
        _inventoryRepository.List(filter);

    public List<Inventory>? Filter(InventoryFilter filter) =>
        _inventoryRepository.Filter(filter);

    public Inventory Save(Inventory model) =>
        _inventoryRepository.Save(model);

    public Inventory Delete(long id) =>
        _inventoryRepository.Delete(id);

}
