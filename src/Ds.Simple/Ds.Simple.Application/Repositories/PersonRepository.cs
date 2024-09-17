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

public class PersonRepository(ISimpleDatabaseContext databaseContext)
    : IdentifiableRepository<IdentifiableEntityLong, long>(databaseContext), IPersonRepository
{

    public override string TableName { get; } = "Person";
    private readonly Func<PersonEntity, PersonFilter, bool> FilterPerson = (x, filter) =>
        (!filter.FullName.HasValue() || x.FullName.Contains(filter.FullName!.Trim(), StringComparison.CurrentCultureIgnoreCase))
        && (!filter.BirthDate.HasValue || x.BirthDate == filter.BirthDate);

    public Person? Get(long id)
    {

        string[] except = [TableName];
        try
        {
            var query = GetQueryable<PersonEntity>()
                .Where(x => x.Id == id)
                .Include(i => i.PersonAddressList)
                .Include(i => i.PersonContactList)
                .Include(i => i.User)
                .FirstOrDefault();

            return query?.MapTo(except);
        }
        catch { throw new Exception(); }
    }

    public PaginatedList<Person>? List(PersonFilter filter)
    {
        string[] except = [TableName];
        try
        {
            var totalRecords = GetQueryable<PersonEntity>().Count();
            var query = ((filter?.PageSize ?? 0) switch
            {
                0 => GetQueryable<PersonEntity>(),
                > 0 => GetQueryable<PersonEntity>()
                    .Skip((filter?.PageIndex ?? 1) * filter!.PageSize)
                    .Take(filter!.PageSize),
                _ => default
            })?
                .Include(i => i.PersonAddressList)
                .Include(i => i.PersonContactList)
                .Include(i => i.User)
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

    public List<Person>? Filter(PersonFilter filter)
    {
        string[] except = [TableName];
        try
        {
            var query = GetQueryable<PersonEntity>()
                .Where(x => FilterPerson(x, filter))
                .Include(i => i.PersonAddressList)
                .Include(i => i.PersonContactList)
                .Include(i => i.User)
                .ToList();

            return query?.Select(s => s.MapTo(except))?.ToList();
        }
        catch { throw new Exception(); }
    }

    public Person Save(Person model)
    {
        try
        {
            var entity = PersonEntity.MapFrom(model);

            CreateOrUpdate(entity);
            SaveChanges();
            ClearChangeTracker();

            return entity?.MapTo() ?? new();
        }
        catch { throw new Exception(); }
    }

    public Person Delete(long id)
    {
        try
        {
            var query = new PersonEntity() { Id = id };

            GetWritable<PersonEntity>().Remove(query);
            SaveChanges();
            ClearChangeTracker();

            return query?.MapTo() ?? new();
        }
        catch { throw new Exception(); }
    }

}
