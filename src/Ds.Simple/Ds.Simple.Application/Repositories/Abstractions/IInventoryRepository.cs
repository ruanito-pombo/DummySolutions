using Ds.Base.Core.Paginateds;
using Ds.Base.Core.Repositories.Abstractions;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;

namespace Ds.Simple.Application.Repositories.Abstractions;

public interface IInventoryRepository : IIdentifiableRepository
{

    Inventory? Get(long id);
    PaginatedList<Inventory>? List(InventoryFilter filter);
    List<Inventory>? Filter(InventoryFilter filter);
    Inventory Save(Inventory model);
    Inventory Delete(long id);

}
