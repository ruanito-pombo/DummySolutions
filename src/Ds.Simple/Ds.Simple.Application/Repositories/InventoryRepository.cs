using Ds.Base.Core.Contexts.Abstractions;
using Ds.Base.Core.Entities;
using Ds.Base.Core.Extensions;
using Ds.Base.Core.Paginateds;
using Ds.Base.Core.Repositories;
using Ds.Simple.Application.Entities;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;
using Ds.Simple.Application.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Ds.Simple.Application.Repositories;

public class InventoryRepository(IDatabaseContext databaseContext)
    : IdentifiableRepository<IdentifiableEntityLong, long>(databaseContext), IInventoryRepository
{

    public override string TableName { get; } = "Inventory";
    private readonly Func<InventoryEntity, InventoryFilter, bool> FilterInventory = (x, filter) =>
        (!filter.TitleName.HasValue() || x.Title!.FullName.Contains(filter.TitleName!.Trim(), StringComparison.CurrentCultureIgnoreCase))
        && (!filter.SupplierName.HasValue() || (x.Supplier != null && x.Supplier.FullName.Contains(filter.SupplierName!.Trim(), StringComparison.CurrentCultureIgnoreCase)))
        && (!filter.AcquisitionDate.HasValue || x.AcquisitionDate.Equals(filter.AcquisitionDate));

    public Inventory? Get(long id)
    {
        string[] except = [TableName, "InventoryList"];
        try
        {
            var query = GetQueryable<InventoryEntity>()
                .Where(x => x.Id == id)
                .Include(i => i.Title)
                .FirstOrDefault();

            return query?.MapTo(except);
        }
        catch { throw new Exception(); }
    }

    public PaginatedList<Inventory>? List(InventoryFilter filter)
    {
        string[] except = [TableName, "InventoryList"];
        try
        {
            var totalRecords = GetQueryable<InventoryEntity>().Count();
            var query = ((filter?.PageSize ?? 0) switch
            {
                0 => GetQueryable<InventoryEntity>(),
                > 0 => GetQueryable<InventoryEntity>()
                    .Skip((filter?.PageIndex ?? 1) * filter!.PageSize)
                    .Take(filter!.PageSize),
                _ => default
            })?
                .Include(i => i.Title)
                .ToList();

            return new()
            {
                TotalRecords = totalRecords,
                TotalPages = (filter?.PageSize ?? 1) > 0 ? (totalRecords / (filter?.PageSize ?? 1) + (totalRecords % (filter?.PageSize ?? 1))
                    is int totalPages && totalPages > 0 ? totalPages : 1) : 1,
                PageSize = filter?.PageSize ?? 0,
                PageIndex = filter?.PageIndex ?? 0,
                Results = query?.Select(s => s.MapTo(except))?.ToList()
            };
        }
        catch { throw new Exception(); }
    }

    public List<Inventory>? Filter(InventoryFilter filter)
    {
        string[] except = [TableName, "InventoryList"];
        try
        {
            var query = GetQueryable<InventoryEntity>()
                .Where(x => FilterInventory(x, filter))
                .Include(i => i.Title)
                .ToList();

            return query?.Select(s => s.MapTo(except))?.ToList();
        }
        catch { throw new Exception(); }
    }

    public Inventory Save(Inventory model)
    {
        try
        {
            var entity = InventoryEntity.MapFrom(model);

            CreateOrUpdate(entity);
            SaveChanges();
            ClearChangeTracker();

            return entity?.MapTo() ?? new();
        }
        catch { throw new Exception(); }
    }

    public Inventory Delete(long id)
    {
        try
        {
            var entity = InventoryEntity.MapFrom(Get(id));
            var query = GetWritable<InventoryEntity>()
                .Remove(entity);
            SaveChanges();
            ClearChangeTracker();

            return entity.MapTo();
        }
        catch { throw new Exception(); }
    }

}
