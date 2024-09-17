using Ds.Base.Domain.Extensions;
using Ds.Base.Domain.Paginateds;
using Ds.Base.EntityFramework.Entities;
using Ds.Base.EntityFramework.Repositories;
using Ds.Simple.Application.Contexts.Abstractions;
using Ds.Simple.Application.Entities;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;
using Ds.Simple.Application.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Ds.Simple.Application.Repositories;

public class PaymentRepository(ISimpleDatabaseContext databaseContext)
    : IdentifiableRepository<IdentifiableEntityLong, long>(databaseContext), IPaymentRepository
{

    public override string TableName { get; } = "Payment";
    private readonly Func<PaymentEntity, PaymentFilter, bool> FilterPayment = (x, filter) =>
        (!filter.CustomerName.HasValue() || (x.Customer != null && x.Customer.FullName.Contains(filter.CustomerName!.Trim(), StringComparison.CurrentCultureIgnoreCase)))
        ;

    public Payment? Get(long id)
    {
        string[] except = [TableName];
        try
        {
            var query = GetQueryable<PaymentEntity>()
                .Where(x => x.Id == id)
                .Include(i => i.Rental)
                .FirstOrDefault();

            return query?.MapTo(except);
        }
        catch { throw new Exception(); }
    }

    public PaginatedList<Payment>? List(PaymentFilter filter)
    {
        string[] except = [TableName];
        try
        {
            var totalRecords = GetQueryable<PaymentEntity>().Count();
            var query = ((filter?.PageSize ?? 0) switch
            {
                0 => GetQueryable<PaymentEntity>(),
                > 0 => GetQueryable<PaymentEntity>()
                    .Skip((filter?.PageIndex ?? 1) * filter!.PageSize)
                    .Take(filter!.PageSize),
                _ => default
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

    public List<Payment>? Filter(PaymentFilter filter)
    {
        string[] except = [TableName];
        try
        {
            var query = GetQueryable<PaymentEntity>()
                .Where(x => FilterPayment(x, filter))
                .Include(i => i.Rental)
                .ToList();

            return query?.Select(s => s.MapTo(except))?.ToList();
        }
        catch { throw new Exception(); }
    }

    public Payment Save(Payment model)
    {
        try
        {
            var entity = PaymentEntity.MapFrom(model);

            CreateOrUpdate(entity);
            SaveChanges();
            ClearChangeTracker();

            return entity?.MapTo() ?? new();
        }
        catch { throw new Exception(); }
    }

    public Payment Delete(long id)
    {
        try
        {
            var entity = PaymentEntity.MapFrom(Get(id));
            var query = GetWritable<PaymentEntity>()
                .Remove(entity);
            SaveChanges();
            ClearChangeTracker();

            return entity.MapTo();
        }
        catch { throw new Exception(); }
    }

}
