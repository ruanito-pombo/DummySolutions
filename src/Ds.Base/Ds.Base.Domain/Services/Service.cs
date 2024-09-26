using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Services.Abstractions;

namespace Ds.Base.Domain.Services;

public class Service(IBusiness business) : IService
{

    protected readonly IBusiness _business = business;

}
