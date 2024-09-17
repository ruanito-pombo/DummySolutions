using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Models.Abstractions;
using Ds.Base.Domain.Services.Abstractions;

namespace Ds.Base.Domain.Services;

public class AuditableService<TAuditable, TId>(IBusiness business)
    : Service<TAuditable, TId>(business), IAuditableService
    where TAuditable : IAuditable<TId>
    where TId : struct
{

}
