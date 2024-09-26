using Ds.Base.Domain.Extensions;
using Ds.Base.Domain.Paginateds;
using Ds.Base.EntityFramework.Entities;
using Ds.Base.EntityFramework.Repositories;
using Ds.Full.Domain.Contexts.Abstractions;
using Ds.Full.Domain.Filters.Finances;
using Ds.Full.Domain.Models.Finances;
using Ds.Full.Domain.Repositories.Abstractions.Finances;
using Ds.Full.MySql.Contexts;
using Ds.Full.MySql.Entities.Finances;
using Microsoft.EntityFrameworkCore;
using static Ds.Full.Domain.Constants.DsFullConstant;

namespace Ds.Full.MySql.Repositories.Finances;

public class PaymentRepository(IDsFullDatabaseContext databaseContext)
    : AuditableRepository<DsFullDatabaseContext, AuditableEntityLong, long>((DsFullDatabaseContext)databaseContext), IPaymentRepository
{

    public override string TableName { get; } = "Payment";

    public async Task<Payment?> Get(long id)
    {
        string[] except = [TableName];
        try
        {
            var query = await GetQueryable<PaymentEntity>()
                .Where(x => x.Id == id)
                .Include(i => i.Rental)
                .FirstOrDefaultAsync();

            return query?.MapTo(except);
        }
        catch { throw new Exception(); }
    }

    public async Task<List<Payment>?> Filter(PaymentFilter filter)
    {
        string[] except = [TableName];
        try
        {
            var query = await GetQueryable<PaymentEntity>()
                .Where(x => (!filter.CustomerName.HasValue() || (x.Customer != null && x.Customer.FullName.Contains(filter.CustomerName!.Trim(), StringComparison.CurrentCultureIgnoreCase))))
                .Include(i => i.Rental)
                .ToListAsync();

            return query?.Select(s => s.MapTo(except))?.ToList();
        }
        catch { throw new Exception(); }
    }

    public async Task<PaginatedList<Payment>?> List(PaymentFilter filter)
    {
        string[] except = [TableName];
        try
        {
            var totalRecords = await GetQueryable<PaymentEntity>().CountAsync();
            var query = ((filter?.PageSize) switch
            {
                > 0 => GetQueryable<PaymentEntity>()
                    .Skip((filter?.PageIndex ?? 1) * (filter?.PageSize ?? MinimumPageSize))
                    .Take(filter?.PageSize ?? MinimumPageSize),
                _ => GetQueryable<PaymentEntity>(),
            })?
                .Include(i => i.Rental)
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

    public async Task<Payment> Delete(long id)
    {
        try
        {
            var entity = PaymentEntity.MapFrom(await Get(id));
            var query = GetWritable<PaymentEntity>()
                .Remove(entity);
            await CommitAsync();
            ClearChangeTracker();

            return entity.MapTo();
        }
        catch { throw new Exception(); }
    }

    public async Task<Payment> Save(Payment model)
    {
        try
        {
            var entity = PaymentEntity.MapFrom(model);

            CreateOrUpdate(entity);
            await CommitAsync();
            ClearChangeTracker();

            return entity?.MapTo() ?? new();
        }
        catch { throw new Exception(); }
    }

}
