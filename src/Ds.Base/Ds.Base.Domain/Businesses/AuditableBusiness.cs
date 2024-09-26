using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Repositories.Abstractions;

namespace Ds.Base.Domain.Businesses;

public class AuditableBusiness(IRepository repository) : Business(repository), IAuditableBusiness
{



}