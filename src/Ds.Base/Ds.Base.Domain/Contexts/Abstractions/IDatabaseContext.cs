using Microsoft.EntityFrameworkCore;

namespace Ds.Base.Domain.Contexts.Abstractions;

public interface IDatabaseContext
{

    void ClearChangeTracker();

    IQueryable<TEntry> GetQueryable<TEntry>() where TEntry : class;

    DbSet<TEntry> GetWritable<TEntry>() where TEntry : class;

    public int SaveChanges();

}
