using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Repositories.Abstractions;

namespace Ds.Base.Domain.Businesses;

public class IdentifiableBusiness(IRepository repository) : Business(repository), IIdentifiableBusiness
{



}