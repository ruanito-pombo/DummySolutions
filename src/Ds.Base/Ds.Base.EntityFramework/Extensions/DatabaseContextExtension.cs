using Ds.Base.Domain.Entities.Abstractions;
using Ds.Base.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Ds.Base.EntityFramework.Extensions;

public static class DatabaseContextIdentifiableExtension
{

    public static TEntry? Get<TEntry, TId>(this DatabaseContext context, TId id)
    where TEntry : class, IIdentifiableEntity<TId>
    where TId : struct =>
        context.Set<TEntry>().FirstOrDefault(x => x.Id.Equals(id));

    public static async Task<TEntry?> GetAsync<TEntry, TId>(this DatabaseContext context, TId id)
    where TEntry : class, IIdentifiableEntity<TId>
    where TId : struct =>
        await context.Set<TEntry>().FirstOrDefaultAsync(x => x.Id.Equals(id));

}

public static class DatabaseContextAuditableExtension
{

    public static TEntity? Get<TEntity, TId>(this DatabaseContext context, TId id)
    where TEntity : class, IAuditableEntity<TId>
    where TId : struct =>
        context.Set<TEntity>().FirstOrDefault(x => x.Id.Equals(id));

    public static async Task<TEntry?> GetAsync<TEntry, TId>(this DatabaseContext context, TId id)
    where TEntry : class, IAuditableEntity<TId>
    where TId : struct =>
        await context.Set<TEntry>().FirstOrDefaultAsync(x => x.Id.Equals(id));

}