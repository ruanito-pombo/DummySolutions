using Ds.Base.Domain.Businesses;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Businesses.Abstractions.Inventories;
using Ds.Full.Domain.Filters.Inventories;
using Ds.Full.Domain.Models.Inventories;
using Ds.Full.Domain.Repositories.Abstractions.Inventories;

namespace Ds.Full.Domain.Businesses.Inventories;

public class InventoryBusiness(IInventoryRepository inventoryRepository) : AuditableBusiness(inventoryRepository), IInventoryBusiness
{

    private readonly IInventoryRepository _inventoryRepository = inventoryRepository;

    public async Task<Inventory?> Get(long id) =>
        await _inventoryRepository.Get(id);

    public async Task<List<Inventory>?> Filter(InventoryFilter filter) =>
        await _inventoryRepository.Filter(filter);

    public async Task<PaginatedList<Inventory>?> List(InventoryFilter filter) =>
        await _inventoryRepository.List(filter);

    public async Task<Inventory> Delete(long id) =>
        await _inventoryRepository.Delete(id);

    public async Task<Inventory> Save(Inventory model) =>
        await _inventoryRepository.Save(model);

}
