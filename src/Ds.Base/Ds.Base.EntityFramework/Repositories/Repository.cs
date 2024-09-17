using Ds.Base.Domain.Contexts.Abstractions;
using Ds.Base.Domain.Entities.Abstractions;
using Ds.Base.Domain.Repositories.Abstractions;
using Ds.Base.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ds.Base.EntityFramework.Repositories;

public abstract class Repository<TEntity, TId>(IDatabaseContext databaseContext) : IRepository
    where TEntity : IEntity
    where TId : struct
{
    protected readonly IDatabaseContext _databaseContext = databaseContext;
    public virtual string TableName { get; private set; } = string.Empty;

    public void ClearChangeTracker() => _databaseContext.ClearChangeTracker();
    public void CreateOrUpdate<TEntry>(TEntry entry) where TEntry : class => _ = entry switch
    {
        AuditableEntityInt => (entry as AuditableEntityInt)!.Id == 0 ? GetWritable<TEntry>().Add(entry) : GetWritable<TEntry>().Update(entry),
        AuditableEntityLong => (entry as AuditableEntityLong)!.Id == 0 ? GetWritable<TEntry>().Add(entry) : GetWritable<TEntry>().Update(entry),
        AuditableEntityShort => (entry as AuditableEntityShort)!.Id == 0 ? GetWritable<TEntry>().Add(entry) : GetWritable<TEntry>().Update(entry),
        IdentifiableEntityInt => (entry as IdentifiableEntityInt)!.Id == 0 ? GetWritable<TEntry>().Add(entry) : GetWritable<TEntry>().Update(entry),
        IdentifiableEntityLong => (entry as IdentifiableEntityLong)!.Id == 0 ? GetWritable<TEntry>().Add(entry) : GetWritable<TEntry>().Update(entry),
        IdentifiableEntityShort => (entry as IdentifiableEntityShort)!.Id == 0 ? GetWritable<TEntry>().Add(entry) : GetWritable<TEntry>().Update(entry),
        _ => (entry as dynamic)!.Id == 0 ? GetWritable<TEntry>().Add(entry) : GetWritable<TEntry>().Update(entry),
    };
    public IQueryable<TEntry> GetQueryable<TEntry>() where TEntry : class => _databaseContext.GetQueryable<TEntry>().AsNoTracking();
    public DbSet<TEntry> GetWritable<TEntry>() where TEntry : class => _databaseContext.GetWritable<TEntry>();
    public virtual int SaveChanges() => _databaseContext.SaveChanges();

}
