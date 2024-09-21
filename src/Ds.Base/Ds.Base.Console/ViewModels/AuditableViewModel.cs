using Ds.Base.Domain.ViewModels.Abstractions;

namespace Ds.Base.Console.ViewModels;

public class AuditableViewModel<TId> : ViewModel, IViewModel, IAuditableViewModel<TId>
    where TId : struct
{
    public TId Id { get; set; } = default;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
}

public class AuditableViewModelInt : ViewModel, IViewModel, IAuditableViewModel<int>
{
    public int Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableViewModelInt() { }
    public AuditableViewModelInt(int id) { Id = id; }
}

public class AuditableViewModelLong : ViewModel, IViewModel, IAuditableViewModel<long>
{
    public long Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableViewModelLong() { }
    public AuditableViewModelLong(long id) { Id = id; }
}

public class AuditableViewModelShort : ViewModel, IViewModel, IAuditableViewModel<short>
{
    public short Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public AuditableViewModelShort() { }
    public AuditableViewModelShort(short id) { Id = id; }
}