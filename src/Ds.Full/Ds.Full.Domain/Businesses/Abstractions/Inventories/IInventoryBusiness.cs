﻿using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Filters.Inventories;
using Ds.Full.Domain.Models.Inventories;

namespace Ds.Full.Domain.Businesses.Abstractions.Inventories;

public interface IInventoryBusiness : IAuditableBusiness
{

    Task<Inventory?> Get(long id);
    Task<List<Inventory>?> Filter(InventoryFilter filter);
    Task<PaginatedList<Inventory>?> List(InventoryFilter filter);
    Task<Inventory> Delete(long id);
    Task<Inventory> Save(Inventory model);

}
