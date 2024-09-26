using Ds.Base.Domain.Paginateds;
using Ds.Base.EntityFramework.Entities;
using Ds.Base.EntityFramework.Repositories;
using Ds.Full.Domain.Contexts.Abstractions;
using Ds.Full.Domain.Filters.Staffs;
using Ds.Full.Domain.Models.Staffs;
using Ds.Full.Domain.Repositories.Abstractions.Staffs;
using Ds.Full.MySql.Contexts;
using Ds.Full.MySql.Entities.Staffs;
using Microsoft.EntityFrameworkCore;
using static Ds.Full.Domain.Constants.DsFullConstant;

namespace Ds.Full.MySql.Repositories.Staffs;

public class ProfileRepository(IDsFullDatabaseContext databaseContext)
    : AuditableRepository<DsFullDatabaseContext, AuditableEntityInt, int>((DsFullDatabaseContext)databaseContext), IProfileRepository
{

    public override string TableName { get; } = "Profile";

    public async Task<Profile?> Get(int id)
    {
        string[] except = [TableName, "ProfileList"];
        try
        {
            var query = await GetQueryable<ProfileEntity>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return query?.MapTo(except);
        }
        catch { throw new Exception(); }
    }

    public async Task<PaginatedList<Profile>?> List(ProfileFilter filter)
    {
        string[] except = [TableName, "ProfileList"];
        try
        {
            var totalRecords = await GetQueryable<ProfileEntity>().CountAsync();
            var query = ((filter?.PageSize) switch
            {
                > 0 => GetQueryable<ProfileEntity>()
                    .Skip((filter?.PageIndex ?? 1) * (filter?.PageSize ?? MinimumPageSize))
                    .Take(filter?.PageSize ?? MinimumPageSize),
                _ => GetQueryable<ProfileEntity>(),
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

    public async Task<List<Profile>?> Filter(ProfileFilter filter)
    {
        string[] except = [TableName, "ProfileList"];
        try
        {
            var query = await GetQueryable<ProfileEntity>()
                .Where(x => (string.IsNullOrEmpty(filter.Description) || (x.Description != null && x.Description.Contains(filter.Description!.Trim(), StringComparison.CurrentCultureIgnoreCase))))
                .ToListAsync();

            return query?.Select(s => s.MapTo(except))?.ToList();
        }
        catch { throw new Exception(); }
    }

    public async Task<Profile> Save(Profile model)
    {
        try
        {
            var entity = ProfileEntity.MapFrom(model);

            CreateOrUpdate(entity);
            await CommitAsync();
            ClearChangeTracker();

            return entity?.MapTo() ?? new();
        }
        catch { throw new Exception(); }
    }

    public async Task<Profile> Delete(int id)
    {
        try
        {
            var entity = ProfileEntity.MapFrom(await Get(id));
            var query = GetWritable<ProfileEntity>()
                .Remove(entity);
            await CommitAsync();
            ClearChangeTracker();

            return entity.MapTo();
        }
        catch { throw new Exception(); }
    }

}
