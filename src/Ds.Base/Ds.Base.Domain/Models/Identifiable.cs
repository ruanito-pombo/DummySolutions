using Ds.Base.Domain.Models.Abstractions;

namespace Ds.Base.Domain.Models;

public class IdentifiableEntity<TId> : Model, IModel, IIdentifiable<TId>
    where TId : struct
{
    public TId Id { get; set; } = default;
}

public class IdentifiableInt : Model, IModel, IIdentifiable<int>
{
    public int Id { get; set; } = 0;
    public IdentifiableInt() { }
    public IdentifiableInt(int id) { Id = id; }
}

public class IdentifiableLong : Model, IModel, IIdentifiable<long>
{
    public long Id { get; set; } = 0;
    public IdentifiableLong() { }
    public IdentifiableLong(long id) { Id = id; }
}

public class IdentifiableShort : Model, IModel, IIdentifiable<short>
{
    public short Id { get; set; } = 0;
    public IdentifiableShort() { }
    public IdentifiableShort(short id) { Id = id; }
}