﻿using Ds.Base.Domain.Paginateds;
using Ds.Base.EntityFramework.Entities;
using Ds.Base.EntityFramework.Repositories;
using Ds.Full.Domain.Contexts.Abstractions;
using Ds.Full.Domain.Filters.Finances;
using Ds.Full.Domain.Filters.Medias;
using Ds.Full.Domain.Models.Medias;
using Ds.Full.Domain.Repositories.Abstractions.Medias;
using Ds.Full.MySql.Contexts;
using Ds.Full.MySql.Entities.Medias;
using Microsoft.EntityFrameworkCore;
using static Ds.Full.Domain.Constants.DsFullConstant;

namespace Ds.Full.MySql.Repositories.Medias;

public class CategoryRepository(IDsFullDatabaseContext databaseContext)
    : AuditableRepository<DsFullDatabaseContext, AuditableEntityInt, int>((DsFullDatabaseContext)databaseContext), ICategoryRepository
{

    public override string TableName { get; } = "Category";

    public async Task<Category?> Get(int id)
    {
        string[] except = [TableName, "CategoryList"];
        try
        {
            var query = await GetQueryable<CategoryEntity>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return query?.MapTo(except);
        }
        catch { throw new Exception(); }
    }

    public async Task<List<Category>?> Filter(CategoryFilter filter)
    {
        string[] except = [TableName, "CategoryList"];
        try
        {
            var query = await GetQueryable<CategoryEntity>()
                .Where(x => (string.IsNullOrEmpty(filter.Description) || (x.Description != null && x.Description.Contains(filter.Description!.Trim(), StringComparison.CurrentCultureIgnoreCase))))
                .ToListAsync();

            return query?.Select(s => s.MapTo(except))?.ToList();
        }
        catch { throw new Exception(); }
    }

    public async Task<PaginatedList<Category>?> List(CategoryFilter filter)
    {
        string[] except = [TableName, "CategoryList"];
        try
        {
            var totalRecords = await GetQueryable<CategoryEntity>().CountAsync();
            var query = ((filter?.PageSize) switch
            {
                > 0 => GetQueryable<CategoryEntity>()
                    .Skip((filter?.PageIndex ?? 1) * (filter?.PageSize ?? MinimumPageSize))
                    .Take(filter?.PageSize ?? MinimumPageSize),
                _ => GetQueryable<CategoryEntity>(),
            })?
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

    public async Task<Category> Delete(int id)
    {
        try
        {
            var entity = CategoryEntity.MapFrom(await Get(id));
            var query = GetWritable<CategoryEntity>()
                .Remove(entity);
            await CommitAsync();
            ClearChangeTracker();

            return entity.MapTo();
        }
        catch { throw new Exception(); }
    }

    public async Task<Category> Save(Category model)
    {
        try
        {
            var entity = CategoryEntity.MapFrom(model);

            CreateOrUpdate(entity);
            await CommitAsync();
            ClearChangeTracker();

            return entity?.MapTo() ?? new();
        }
        catch { throw new Exception(); }
    }

}
