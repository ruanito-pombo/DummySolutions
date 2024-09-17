using Ds.Base.Domain.Contexts.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Ds.Base.EntityFramework.Contexts;

public class DatabaseContext(DbContextOptions options) : DbContext(options), IDatabaseContext
{

    public void ClearChangeTracker() => ChangeTracker.Clear();

    public IQueryable<TEntry> GetQueryable<TEntry>() where TEntry : class => Set<TEntry>().AsNoTracking();

    public DbSet<TEntry> GetWritable<TEntry>() where TEntry : class => Set<TEntry>();

    public override int SaveChanges() =>
        base.SaveChanges();

}
