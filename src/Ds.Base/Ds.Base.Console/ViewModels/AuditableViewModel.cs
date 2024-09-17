using Ds.Base.Domain.Models.Abstractions;
using Ds.Base.Domain.Consoles.ViewModels.Abstractions;

namespace Ds.Base.Console.ViewModels;

public class AuditableViewModel<TId> : IAuditableViewModel<TId>, IModel
    where TId : struct
{
    public TId Id { get; set; } = default;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
}

public class AuditableViewModelInt : IAuditableViewModel<int>, IModel
{
    public int Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableViewModelInt() { }
    public AuditableViewModelInt(int id) { Id = id; }
}

public class AuditableViewModelLong : IAuditableViewModel<long>, IModel
{
    public long Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableViewModelLong() { }
    public AuditableViewModelLong(long id) { Id = id; }
}

public class AuditableViewModelShort : IAuditableViewModel<short>, IModel
{
    public short Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableViewModelShort() { }
    public AuditableViewModelShort(short id) { Id = id; }
}