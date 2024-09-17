using Ds.Base.Domain.Models.Abstractions;
using Ds.Base.Domain.Consoles.ViewModels.Abstractions;

namespace Ds.Base.Console.ViewModels;

public class IdentifiableViewModel<TId> : IIdentifiableViewModel<TId>, IModel
    where TId : struct
{
    public TId Id { get; set; } = default;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
}

public class IdentifiableViewModelInt : IIdentifiableViewModel<int>, IModel
{
    public int Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public IdentifiableViewModelInt() { }
    public IdentifiableViewModelInt(int id) { Id = id; }
}

public class IdentifiableViewModelLong : IIdentifiableViewModel<long>, IModel
{
    public long Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public IdentifiableViewModelLong() { }
    public IdentifiableViewModelLong(long id) { Id = id; }
}

public class IdentifiableViewModelShort : IIdentifiableViewModel<short>, IModel
{
    public short Id { get; set; } = 0;
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
    public IdentifiableViewModelShort() { }
    public IdentifiableViewModelShort(short id) { Id = id; }
}