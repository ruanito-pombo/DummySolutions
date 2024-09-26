using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Services.Abstractions;

namespace Ds.Base.Domain.Services;

public class AuditableService(IBusiness business) : Service(business), IAuditableService
{



}
