using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Models.Abstractions;
using Ds.Base.Domain.Repositories.Abstractions;

namespace Ds.Base.Domain.Businesses;

public class IdentifiableBusiness<TIdentifiable, TId>(IRepository repository)
        : Business<TIdentifiable, TId>(repository), IIdentifiableBusiness
    where TIdentifiable : IIdentifiable<TId>
    where TId : struct
{

}
