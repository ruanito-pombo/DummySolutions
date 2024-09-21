using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Repositories.Abstractions;
using Ds.Full.Domain.Filters.Inventories;
using Ds.Full.Domain.Models.Inventories;

namespace Ds.Full.Domain.Repositories.Abstractions.Inventories;

public interface IInventoryRepository : IIdentifiableRepository
{

    Inventory? Get(long id);
    PaginatedList<Inventory>? List(InventoryFilter filter);
    List<Inventory>? Filter(InventoryFilter filter);
    Inventory Save(Inventory model);
    Inventory Delete(long id);

}
