using Ds.Base.Domain.Entities.Abstractions;

namespace Ds.Base.EntityFramework.Entities;

public class IdentifiableEntity<TId> : Entity, IEntity, IIdentifiableEntity<TId>
    where TId : struct
{
    public TId Id { get; set; } = default;
}

public class IdentifiableEntityInt : Entity, IEntity, IIdentifiableEntity<int>
{
    public int Id { get; set; } = 0;
    public IdentifiableEntityInt() { }
    public IdentifiableEntityInt(int id) { Id = id; }
}

public class IdentifiableEntityLong : Entity, IEntity, IIdentifiableEntity<long>
{
    public long Id { get; set; } = 0;
    public IdentifiableEntityLong() { }
    public IdentifiableEntityLong(long id) { Id = id; }
}

public class IdentifiableEntityShort : Entity, IEntity, IIdentifiableEntity<short>
{
    public short Id { get; set; } = 0;
    public IdentifiableEntityShort() { }
    public IdentifiableEntityShort(short id) { Id = id; }
}