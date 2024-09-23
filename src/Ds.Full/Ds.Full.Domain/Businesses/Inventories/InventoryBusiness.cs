using Ds.Base.Domain.Businesses;
using Ds.Base.Domain.Models;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Businesses.Abstractions.Inventories;
using Ds.Full.Domain.Filters.Inventories;
using Ds.Full.Domain.Models.Inventories;
using Ds.Full.Domain.Repositories.Abstractions.Inventories;

namespace Ds.Full.Domain.Businesses.Inventories;

public class InventoryBusiness(IInventoryRepository inventoryRepository)
    : AuditableBusiness<AuditableLong, long>(inventoryRepository), IInventoryBusiness
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
