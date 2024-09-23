using Ds.Base.Domain.Paginateds;
using Ds.Base.EntityFramework.Entities;
using Ds.Base.EntityFramework.Repositories;
using Ds.Simple.Application.Contexts.Abstractions;
using Ds.Simple.Application.Entities;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;
using Ds.Simple.Application.Repositories.Abstractions;
using static Ds.Simple.Application.Constants.DsSimpleConstant;

namespace Ds.Simple.Application.Repositories;

public class CategoryRepository(IDsSimpleDatabaseContext databaseContext)
    : IdentifiableRepository<IdentifiableEntityInt, int>(databaseContext), ICategoryRepository
{

    public override string TableName { get; } = "Category";

    public Category? Get(int id)
    {
        string[] except = [TableName, "CategoryList"];
        try
        {
            var query = GetQueryable<CategoryEntity>()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            return query?.MapTo(except);
        }
        catch { throw new Exception(); }
    }

    public PaginatedList<Category>? List(CategoryFilter filter)
    {
        string[] except = [TableName, "CategoryList"];
        try
        {
            var totalRecords = GetQueryable<CategoryEntity>().Count();
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

    public List<Category>? Filter(CategoryFilter filter)
    {
        string[] except = [TableName, "CategoryList"];
        try
        {
            var query = GetQueryable<CategoryEntity>()
                .Where(x => string.IsNullOrEmpty(filter.Description) || x.Description.Contains(filter.Description!.Trim(), StringComparison.CurrentCultureIgnoreCase))
                .ToList();

            return query?.Select(s => s.MapTo(except))?.ToList();
        }
        catch { throw new Exception(); }
    }

    public Category Save(Category model)
    {
        try
        {
            var entity = CategoryEntity.MapFrom(model);

            CreateOrUpdate(entity);
            SaveChanges();
            ClearChangeTracker();

            return entity?.MapTo() ?? new();
        }
        catch { throw new Exception(); }
    }

    public Category Delete(int id)
    {
        try
        {
            var entity = CategoryEntity.MapFrom(Get(id));
            var query = GetWritable<CategoryEntity>()
                .Remove(entity);
            SaveChanges();
            ClearChangeTracker();

            return entity.MapTo();
        }
        catch { throw new Exception(); }
    }

}
