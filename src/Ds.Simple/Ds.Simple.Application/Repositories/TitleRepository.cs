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
using static Ds.Simple.Application.Constants.DsSimpleConstant;

namespace Ds.Simple.Application.Repositories;

public class TitleRepository(IDsSimpleDatabaseContext databaseContext)
    : IdentifiableRepository<IdentifiableEntityLong, long>(databaseContext), ITitleRepository
{

    public override string TableName { get; } = "Title";

    public Title? Get(long id)
    {
        string[] except = [TableName, "TitleAuthorList", "TitleProducerList"];
        try
        {
            var query = GetQueryable<TitleEntity>()
                .Where(x => x.Id == id)
                .Include(i => i.Author)
                .FirstOrDefault();

            return query?.MapTo(except);
        }
        catch { throw new Exception(); }
    }

    public PaginatedList<Title>? List(TitleFilter filter)
    {
        string[] except = [TableName, "TitleAuthorList", "TitleProducerList"];
        try
        {
            var totalRecords = GetQueryable<TitleEntity>().Count();
            var query = ((filter?.PageSize) switch
            {
                > 0 => GetQueryable<TitleEntity>()
                    .Skip((filter?.PageIndex ?? 1) * (filter?.PageSize ?? MinimumPageSize))
                    .Take(filter?.PageSize ?? MinimumPageSize),
                _ => GetQueryable<TitleEntity>(),
            })?
                .Include(i => i.Author)
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

    public List<Title>? Filter(TitleFilter filter)
    {
        string[] except = [TableName, "TitleAuthorList", "TitleProducerList"];
        try
        {
            var query = GetQueryable<TitleEntity>()
                .Where(x => (!filter.AuthorName.HasValue() || (x.Author != null && x.Author.FullName.Contains(filter.AuthorName!.Trim(), StringComparison.CurrentCultureIgnoreCase)))
                    && (!filter.ProducerName.HasValue() || (x.Producer != null && x.Producer.FullName.Contains(filter.ProducerName!.Trim(), StringComparison.CurrentCultureIgnoreCase)))
                    && (!filter.FullName.HasValue() || x.FullName.Contains(filter.FullName!.Trim(), StringComparison.CurrentCultureIgnoreCase)))
                .Include(i => i.Author)
                .ToList();

            return query?.Select(s => s.MapTo(except))?.ToList();
        }
        catch { throw new Exception(); }
    }

    public Title Save(Title model)
    {
        try
        {
            var entity = TitleEntity.MapFrom(model);

            CreateOrUpdate(entity);
            SaveChanges();
            ClearChangeTracker();

            return entity?.MapTo() ?? new();
        }
        catch { throw new Exception(); }
    }

    public Title Delete(long id)
    {
        try
        {
            var entity = TitleEntity.MapFrom(Get(id));
            var query = GetWritable<TitleEntity>()
                .Remove(entity);
            SaveChanges();
            ClearChangeTracker();

            return entity.MapTo();
        }
        catch { throw new Exception(); }
    }

}
