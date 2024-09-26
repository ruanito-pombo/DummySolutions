using Ds.Base.Domain.Extensions;
using Ds.Base.Domain.Paginateds;
using Ds.Base.EntityFramework.Entities;
using Ds.Base.EntityFramework.Repositories;
using Ds.Full.Domain.Contexts.Abstractions;
using Ds.Full.Domain.Filters.Rentals;
using Ds.Full.Domain.Models.Rentals;
using Ds.Full.Domain.Repositories.Abstractions.Rentals;
using Ds.Full.MySql.Contexts;
using Ds.Full.MySql.Entities.Rentals;
using Microsoft.EntityFrameworkCore;
using static Ds.Full.Domain.Constants.DsFullConstant;

namespace Ds.Full.MySql.Repositories.Rentals;

public class RentalRepository(IDsFullDatabaseContext databaseContext)
    : AuditableRepository<DsFullDatabaseContext, AuditableEntityLong, long>((DsFullDatabaseContext)databaseContext), IRentalRepository
{

    public override string TableName { get; } = "Rental";

    public async Task<Rental?> Get(long id)
    {
        string[] except = [TableName];
        try
        {
            var query = await GetQueryable<RentalEntity>()
                .Where(x => x.Id == id)
                .Include(i => i.Payment)
                .FirstOrDefaultAsync();

            return query?.MapTo(except);
        }
        catch { throw new Exception(); }
    }

    public async Task<List<Rental>?> Filter(RentalFilter filter)
    {
        string[] except = [TableName];
        try
        {
            var query = await GetQueryable<RentalEntity>()
                .Where(x => (!filter.CustomerName.HasValue() || (x.Customer != null && x.Customer.FullName.Contains(filter.CustomerName!.Trim(), StringComparison.CurrentCultureIgnoreCase))))
                .Include(i => i.Payment)
                .ToListAsync();

            return query?.Select(s => s.MapTo(except))?.ToList();
        }
        catch { throw new Exception(); }
    }

    public async Task<PaginatedList<Rental>?> List(RentalFilter filter)
    {
        string[] except = [TableName];
        try
        {
            var totalRecords = await GetQueryable<RentalEntity>().CountAsync();
            var query = ((filter?.PageSize) switch
            {
                > 0 => GetQueryable<RentalEntity>()
                    .Skip((filter?.PageIndex ?? 1) * (filter?.PageSize ?? MinimumPageSize))
                    .Take(filter?.PageSize ?? MinimumPageSize),
                _ => GetQueryable<RentalEntity>(),
            })?
                .Include(i => i.Payment)
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

    public async Task<Rental> Delete(long id)
    {
        try
        {
            var entity = RentalEntity.MapFrom(await Get(id));
            var query = GetWritable<RentalEntity>()
                .Remove(entity);
            await CommitAsync();
            ClearChangeTracker();

            return entity.MapTo();
        }
        catch { throw new Exception(); }
    }

    public async Task<Rental> Save(Rental model)
    {
        try
        {
            var entity = RentalEntity.MapFrom(model);

            CreateOrUpdate(entity);
            await CommitAsync();
            ClearChangeTracker();

            return entity?.MapTo() ?? new();
        }
        catch { throw new Exception(); }
    }

}
