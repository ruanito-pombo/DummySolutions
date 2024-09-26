using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Repositories.Abstractions;

namespace Ds.Base.Domain.Businesses;

public class Business(IRepository repository) : IBusiness
{

    protected readonly IRepository _repository = repository;

}
