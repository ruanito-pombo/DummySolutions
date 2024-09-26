using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ds.Base.Domain.Contexts.Abstractions;

public interface IDatabaseContext
{

    void ClearChangeTracker();
    Task ClearChangeTrackerAsync();

    IQueryable<TEntry> GetQueryable<TEntry>() where TEntry : class;
    DbSet<TEntry> GetWritable<TEntry>() where TEntry : class;

    IDbContextTransaction BeginTransaction();
    Task<IDbContextTransaction> BeginTransactionAsync();
    int Commit();
    Task<int> CommitAsync();
    void Rollback();
    Task RollbackAsync();

}
