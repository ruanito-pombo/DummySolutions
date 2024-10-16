﻿using Ds.Base.Domain.Extensions;
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

public class UserRepository(IDsSimpleDatabaseContext databaseContext)
    : IdentifiableRepository<IdentifiableEntityInt, int>(databaseContext), IUserRepository
{

    public override string TableName { get; } = "User";

    public User? Get(int id)
    {
        string[] except = [TableName, "UserList"];
        try
        {
            var query = GetQueryable<UserEntity>()
                .Where(x => x.Id == id)
                .Include(i => i.Profile)
                .Include(i => i.Person)
                .FirstOrDefault();

            return query?.MapTo(except);
        }
        catch { throw new Exception(); }
    }

    public PaginatedList<User>? List(UserFilter filter)
    {
        string[] except = [TableName, "UserList"];
        try
        {
            var totalRecords = GetQueryable<UserEntity>().Count();
            var query = ((filter?.PageSize) switch
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

    public List<User>? Filter(UserFilter filter)
    {
        string[] except = [TableName, "UserList"];
        try
        {
            var query = GetQueryable<UserEntity>()
                .Where(x => !filter.UserName.HasValue() || x.UserName.Contains(filter.UserName!.Trim(), StringComparison.CurrentCultureIgnoreCase))
                .Include(i => i.Person)
                .Include(i => i.Profile)
                .ToList();

            return query?.Select(s => s.MapTo(except))?.ToList();
        }
        catch { throw new Exception(); }
    }

    public User Save(User model)
    {
        try
        {
            var entity = UserEntity.MapFrom(model);

            CreateOrUpdate(entity);
            SaveChanges();
            ClearChangeTracker();

            return entity?.MapTo() ?? new();
        }
        catch { throw new Exception(); }
    }

    public User Delete(int id)
    {
        try
        {
            var entity = UserEntity.MapFrom(Get(id));
            var query = GetWritable<UserEntity>()
                .Remove(entity);
            SaveChanges();
            ClearChangeTracker();

            return entity.MapTo();
        }
        catch { throw new Exception(); }
    }

}
