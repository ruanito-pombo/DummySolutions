using Ds.Base.Domain.Invokers.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ds.Base.Domain.Repositories.Abstractions;

public interface IRepository : IInvoker
{

    void ClearChangeTracker();
    Task ClearChangeTrackerAsync();

    string TableName { get; }

    IQueryable<TEntry> GetQueryable<TEntry>() where TEntry : class;
    DbSet<TEntry> GetWritable<TEntry>() where TEntry : class;

    void CreateOrUpdate<TEntry>(TEntry entry) where TEntry : class;
    Task CreateOrUpdateAsync<TEntry>(TEntry entry) where TEntry : class;

    IDbContextTransaction BeginTransaction();
    Task<IDbContextTransaction> BeginTransactionAsync();
    int Commit();
    Task<int> CommitAsync();
    void Rollback();
    Task RollbackAsync();

}
