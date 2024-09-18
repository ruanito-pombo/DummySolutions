using Ds.Base.Domain.Models.Abstractions;

namespace Ds.Base.Domain.Models;

public class Identifiable<TId> : IModel, IIdentifiable<TId>
    where TId : struct
{
    public TId Id { get; set; } = default;
}

public class IdentifiableInt : IModel, IIdentifiable<int>
{
    public int Id { get; set; } = 0;
    public IdentifiableInt() { }
    public IdentifiableInt(int id) { Id = id; }
}

public class IdentifiableLong : IModel, IIdentifiable<long>
{
    public long Id { get; set; } = 0;
    public IdentifiableLong() { }
    public IdentifiableLong(long id) { Id = id; }
}

public class IdentifiableShort : IModel, IIdentifiable<short>
{
    public short Id { get; set; } = 0;
    public IdentifiableShort() { }
    public IdentifiableShort(short id) { Id = id; }
}