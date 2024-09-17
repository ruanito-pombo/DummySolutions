using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Models.Abstractions;
using Ds.Base.Domain.Services.Abstractions;

namespace Ds.Base.Domain.Services;

public class IdentifiableService<TIdentifiable, TId>(IBusiness business)
        : Service<TIdentifiable, TId>(business), IIdentifiableService
    where TIdentifiable : IIdentifiable<TId>
    where TId : struct
{

}
