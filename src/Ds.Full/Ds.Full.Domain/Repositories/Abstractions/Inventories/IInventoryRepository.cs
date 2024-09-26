using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Repositories.Abstractions;
using Ds.Full.Domain.Filters.Inventories;
using Ds.Full.Domain.Models.Inventories;

namespace Ds.Full.Domain.Repositories.Abstractions.Inventories;

public interface IInventoryRepository : IAuditableRepository
{

    Task<Inventory?> Get(long id);
    Task<List<Inventory>?> Filter(InventoryFilter filter);
    Task<PaginatedList<Inventory>?> List(InventoryFilter filter);
    Task<Inventory> Delete(long id);
    Task<Inventory> Save(Inventory model);

}
