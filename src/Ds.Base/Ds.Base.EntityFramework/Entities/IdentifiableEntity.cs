using Ds.Base.Domain.Entities.Abstractions;

namespace Ds.Base.EntityFramework.Entities;

public class IdentifiableEntity<TId> : IIdentifiableEntity<TId>, IEntity
    where TId : struct
{
    public TId Id { get; set; } = default;
}

public class IdentifiableEntityInt : IIdentifiableEntity<int>, IEntity
{
    public int Id { get; set; } = 0;
    public IdentifiableEntityInt() { }
    public IdentifiableEntityInt(int id) { Id = id; }
}

public class IdentifiableEntityLong : IIdentifiableEntity<long>, IEntity
{
    public long Id { get; set; } = 0;
    public IdentifiableEntityLong() { }
    public IdentifiableEntityLong(long id) { Id = id; }
}

public class IdentifiableEntityShort : IIdentifiableEntity<short>, IEntity
{
    public short Id { get; set; } = 0;
    public IdentifiableEntityShort() { }
    public IdentifiableEntityShort(short id) { Id = id; }
}