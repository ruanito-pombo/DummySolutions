using Ds.Base.Core.Paginateds;
using Ds.Base.Core.Services.Abstractions;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;

namespace Ds.Simple.Application.Services.Abstractions;

public interface IInventoryService : IIdentifiableService, IService
{

    Inventory? Get(long id);
    PaginatedList<Inventory>? List(InventoryFilter filter);
    List<Inventory>? Filter(InventoryFilter filter);
    Inventory Save(Inventory model);
    Inventory Delete(long id);

}
