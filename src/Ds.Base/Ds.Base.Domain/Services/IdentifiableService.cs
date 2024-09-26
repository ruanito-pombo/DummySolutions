using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Services.Abstractions;

namespace Ds.Base.Domain.Services;

public class IdentifiableService(IBusiness business) : Service(business), IIdentifiableService
{



}
