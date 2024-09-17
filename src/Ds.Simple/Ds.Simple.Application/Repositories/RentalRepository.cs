﻿using Ds.Base.Core.Contexts.Abstractions;
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

public class RentalRepository(IDatabaseContext databaseContext)
    : IdentifiableRepository<IdentifiableEntityLong, long>(databaseContext), IRentalRepository
{

    public override string TableName { get; } = "Rental";
    private readonly Func<RentalEntity, RentalFilter, bool> FilterRental = (x, filter) =>
        (!filter.CustomerName.HasValue() || (x.Customer != null && x.Customer.FullName.Contains(filter.CustomerName!.Trim(), StringComparison.CurrentCultureIgnoreCase)))
        ;

    public Rental? Get(long id)
    {
        string[] except = [TableName];
        try
        {
            var query = GetQueryable<RentalEntity>()
                .Where(x => x.Id == id)
                .Include(i => i.Payment)
                .FirstOrDefault();

            return query?.MapTo(except);
        }
        catch { throw new Exception(); }
    }

    public PaginatedList<Rental>? List(RentalFilter filter)
    {
        string[] except = [TableName];
        try
        {
            var totalRecords = GetQueryable<RentalEntity>().Count();
            var query = ((filter?.PageSize ?? 0) switch
            {
                0 => GetQueryable<RentalEntity>(),
                > 0 => GetQueryable<RentalEntity>()
                    .Skip((filter?.PageIndex ?? 1) * filter!.PageSize)
                    .Take(filter!.PageSize),
                _ => default
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

    public List<Rental>? Filter(RentalFilter filter)
    {
        string[] except = [TableName];
        try
        {
            var query = GetQueryable<RentalEntity>()
                .Where(x => FilterRental(x, filter))
                .Include(i => i.Payment)
                .ToList();

            return query?.Select(s => s.MapTo(except))?.ToList();
        }
        catch { throw new Exception(); }
    }

    public Rental Save(Rental model)
    {
        try
        {
            var entity = RentalEntity.MapFrom(model);

            CreateOrUpdate(entity);
            SaveChanges();
            ClearChangeTracker();

            return entity?.MapTo() ?? new();
        }
        catch { throw new Exception(); }
    }

    public Rental Delete(long id)
    {
        try
        {
            var entity = RentalEntity.MapFrom(Get(id));
            var query = GetWritable<RentalEntity>()
                .Remove(entity);
            SaveChanges();
            ClearChangeTracker();

            return entity.MapTo();
        }
        catch { throw new Exception(); }
    }

}
