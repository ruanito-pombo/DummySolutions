using Ds.Base.Domain.Extensions;
using Ds.Base.Domain.Paginateds;
using Ds.Base.EntityFramework.Entities;
using Ds.Base.EntityFramework.Repositories;
using Ds.Full.Domain.Contexts.Abstractions;
using Ds.Full.Domain.Filters.Medias;
using Ds.Full.Domain.Models.Medias;
using Ds.Full.Domain.Repositories.Abstractions.Medias;
using Ds.Full.MySql.Contexts;
using Ds.Full.MySql.Entities.Medias;
using Microsoft.EntityFrameworkCore;
using static Ds.Full.Domain.Constants.DsFullConstant;

namespace Ds.Full.MySql.Repositories.Medias;

public class TitleRepository(IDsFullDatabaseContext databaseContext)
    : AuditableRepository<DsFullDatabaseContext, AuditableEntityLong, long>((DsFullDatabaseContext)databaseContext), ITitleRepository
{

    public override string TableName { get; } = "Title";

    public async Task<Title?> Get(long id)
    {
        string[] except = [TableName, "TitleAuthorList", "TitleProducerList"];
        try
        {
            var query = await GetQueryable<TitleEntity>()
                .Where(x => x.Id == id)
                .Include(i => i.Author)
                .FirstOrDefaultAsync();

            return query?.MapTo(except);
        }
        catch { throw new Exception(); }
    }

    public async Task<List<Title>?> Filter(TitleFilter filter)
    {
        string[] except = [TableName, "TitleAuthorList", "TitleProducerList"];
        try
        {
            var query = await GetQueryable<TitleEntity>()
                .Where(x => (!filter.AuthorName.HasValue() || (x.Author != null && x.Author.FullName.Contains(filter.AuthorName!.Trim(), StringComparison.CurrentCultureIgnoreCase)))
                    && (!filter.ProducerName.HasValue() || (x.Producer != null && x.Producer.FullName.Contains(filter.ProducerName!.Trim(), StringComparison.CurrentCultureIgnoreCase)))
                    && (!filter.FullName.HasValue() || x.FullName.Contains(filter.FullName!.Trim(), StringComparison.CurrentCultureIgnoreCase)))
                .Include(i => i.Author)
                .ToListAsync();

            return query?.Select(s => s.MapTo(except))?.ToList();
        }
        catch { throw new Exception(); }
    }

    public async Task<PaginatedList<Title>?> List(TitleFilter filter)
    {
        string[] except = [TableName, "TitleAuthorList", "TitleProducerList"];
        try
        {
            var totalRecords = await GetQueryable<TitleEntity>().CountAsync();
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

    public async Task<Title> Delete(long id)
    {
        try
        {
            var entity = TitleEntity.MapFrom(await Get(id));
            var query = GetWritable<TitleEntity>()
                .Remove(entity);
            await CommitAsync();
            ClearChangeTracker();

            return entity.MapTo();
        }
        catch { throw new Exception(); }
    }

    public async Task<Title> Save(Title model)
    {
        try
        {
            var entity = TitleEntity.MapFrom(model);

            CreateOrUpdate(entity);
            await CommitAsync();
            ClearChangeTracker();

            return entity?.MapTo() ?? new();
        }
        catch { throw new Exception(); }
    }

}
