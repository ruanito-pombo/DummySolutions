using Ds.Base.Domain.Entities.Abstractions;
using Ds.Base.Domain.Repositories.Abstractions;
using Ds.Base.EntityFramework.Contexts;
using Ds.Base.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ds.Base.EntityFramework.Repositories;

public abstract class Repository<TDatabaseContext, TEntity, TId>(TDatabaseContext databaseContext) : IRepository
where TDatabaseContext : DatabaseContext
where TEntity : IEntity
where TId : struct
{

    private readonly TDatabaseContext _databaseContext = databaseContext; protected TDatabaseContext Context { get => _databaseContext; }
    private string _tableName = string.Empty; public virtual string TableName { get => _tableName; private set => _tableName = value; }

    public void ClearChangeTracker() => 
        _databaseContext.ClearChangeTracker();
    public async Task ClearChangeTrackerAsync() =>
        await _databaseContext.ClearChangeTrackerAsync();

    public IQueryable<TEntry> GetQueryable<TEntry>() where TEntry : class => 
        _databaseContext.GetQueryable<TEntry>().AsNoTracking();
    public DbSet<TEntry> GetWritable<TEntry>() where TEntry : class => 
        _databaseContext.GetWritable<TEntry>();
    
    public void CreateOrUpdate<TEntry>(TEntry entry) where TEntry : class => 
        _databaseContext.CreateOrUpdate(entry);
    public async Task CreateOrUpdateAsync<TEntry>(TEntry entry) where TEntry : class => 
        await _databaseContext.CreateOrUpdateAsync(entry);

    public virtual IDbContextTransaction BeginTransaction() =>
        _databaseContext.BeginTransaction();
    public virtual async Task<IDbContextTransaction> BeginTransactionAsync() =>
        await _databaseContext.BeginTransactionAsync();
    public virtual int Commit() => 
        _databaseContext.Commit();
    public virtual async Task<int> CommitAsync() =>
        await _databaseContext.CommitAsync();
    public virtual void Rollback() =>
        _databaseContext.Rollback();
    public virtual async Task RollbackAsync() =>
        await _databaseContext.RollbackAsync();

}
