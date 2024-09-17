using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Models.Abstractions;
using Ds.Base.Domain.Repositories.Abstractions;

namespace Ds.Base.Domain.Businesses;

public class AuditableBusiness<TAuditable, TId>(IRepository repository)
    : Business<TAuditable, TId>(repository), IAuditableBusiness
    where TAuditable : IAuditable<TId>
    where TId : struct
{

}
