using Ds.Base.Domain.ViewModels.Abstractions;

namespace Ds.Base.Console.ViewModels;

public class IdentifiableViewModel<TId> : ViewModel, IViewModel, IIdentifiableViewModel<TId>
    where TId : struct
{
    public TId Id { get; set; } = default;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
}

public class IdentifiableViewModelInt : ViewModel, IViewModel, IIdentifiableViewModel<int>
{
    public int Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public IdentifiableViewModelInt() { }
    public IdentifiableViewModelInt(int id) { Id = id; }
}

public class IdentifiableViewModelLong : ViewModel, IViewModel, IIdentifiableViewModel<long>
{
    public long Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public IdentifiableViewModelLong() { }
    public IdentifiableViewModelLong(long id) { Id = id; }
}

public class IdentifiableViewModelShort : ViewModel, IViewModel, IIdentifiableViewModel<short>
{
    public short Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public IdentifiableViewModelShort() { }
    public IdentifiableViewModelShort(short id) { Id = id; }
}