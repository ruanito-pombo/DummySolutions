using Ds.Base.Domain.Contexts.Abstractions;
using Ds.Base.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ds.Base.EntityFramework.Contexts;

public class DatabaseContext(DbContextOptions options) : DbContext(options), IDatabaseContext
{

    public void ClearChangeTracker() => 
        ChangeTracker.Clear();
    public async Task ClearChangeTrackerAsync() =>
        await Task.Run(() => ChangeTracker.Clear());

    public IQueryable<TEntry> GetQueryable<TEntry>() where TEntry : class => 
        Set<TEntry>().AsNoTracking();
    public DbSet<TEntry> GetWritable<TEntry>() where TEntry : class => 
        Set<TEntry>();

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
    public async Task CreateOrUpdateAsync<TEntry>(TEntry entry) where TEntry : class =>
        await Task.Run(() => CreateOrUpdate(entry));

    public IDbContextTransaction BeginTransaction() =>
        base.Database.BeginTransaction();
    public async Task<IDbContextTransaction> BeginTransactionAsync() =>
        await base.Database.BeginTransactionAsync();
    public int Commit() =>
        base.SaveChanges();
    public async Task<int> CommitAsync() =>
        await base.SaveChangesAsync();
    public void Rollback() =>
        throw new NotImplementedException();
    public async Task RollbackAsync() =>
        await Task.Run(() => throw new NotImplementedException());
        

}
