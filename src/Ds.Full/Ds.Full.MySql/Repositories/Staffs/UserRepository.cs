using Ds.Base.Domain.Entities.Abstractions;
using Ds.Base.Domain.Extensions;
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

public class UserRepository(IDsFullDatabaseContext context)
    : AuditableRepository<DsFullDatabaseContext, AuditableEntityInt, int>((DsFullDatabaseContext)context), IUserRepository
{

    public override string TableName { get; } = "User";

    public async Task<User?> Get(int id)
    {
        string[] except = [TableName, "UserList"];
        try
        {
            var query = await GetQueryable<UserEntity>()
                .Where(x => x.Id == id)
                .Include(i => i.Profile)
                .Include(i => i.Person)
                .FirstOrDefaultAsync();

            return query?.MapTo(except);
        }
        catch { throw new Exception(); }
    }

    public async Task<List<User>?> Filter(UserFilter filter)
    {
        string[] except = [TableName, "UserList"];
        try
        {
            var query = await GetQueryable<UserEntity>()
                .Where(x => !filter.UserName.HasValue() || x.UserName.Contains(filter.UserName!.Trim(), StringComparison.CurrentCultureIgnoreCase))
                .Include(i => i.Person)
                .Include(i => i.Profile)
                .ToListAsync();

            return query?.Select(s => s.MapTo(except))?.ToList();
        }
        catch { throw new Exception(); }
    }

    public async Task<PaginatedList<User>?> List(UserFilter filter)
    {
        string[] except = [TableName, "UserList"];
        try
        {
            var totalRecords = await GetQueryable<UserEntity>().CountAsync();
            var query = ((filter?.PageSize ?? 0) switch
            {
                > 0 => GetQueryable<UserEntity>()
                    .Skip((filter?.PageIndex ?? 1) * (filter?.PageSize ?? MinimumPageSize))
                    .Take(filter?.PageSize ?? MinimumPageSize),
                _ => GetQueryable<UserEntity>(),
            })?
                .Include(i => i.Profile)
                .Include(i => i.Person)
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

    public async Task<User> Save(User model)
    {
        try
        {
            var entity = UserEntity.MapFrom(model);

            CreateOrUpdate(entity);
            await CommitAsync();
            ClearChangeTracker();

            return entity?.MapTo() ?? new();
        }
        catch { throw new Exception(); }
    }

    public async Task<User> Delete(int id)
    {
        try
        {
            var entity = UserEntity.MapFrom(await Get(id));
            var query = GetWritable<UserEntity>()
                .Remove(entity);
            await CommitAsync();
            ClearChangeTracker();

            return entity.MapTo();
        }
        catch { throw new Exception(); }
    }

}
