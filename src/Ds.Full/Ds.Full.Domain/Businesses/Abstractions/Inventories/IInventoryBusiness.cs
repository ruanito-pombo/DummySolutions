using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Filters.Inventories;
using Ds.Full.Domain.Models.Inventories;

namespace Ds.Full.Domain.Businesses.Abstractions.Inventories;

public interface IInventoryBusiness : IAuditableBusiness
{

    Inventory? Get(long id);
    PaginatedList<Inventory>? List(InventoryFilter filter);
    List<Inventory>? Filter(InventoryFilter filter);
    Inventory Save(Inventory model);
    Inventory Delete(long id);

}
