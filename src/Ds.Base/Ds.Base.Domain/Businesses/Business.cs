using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Models.Abstractions;
using Ds.Base.Domain.Repositories.Abstractions;

namespace Ds.Base.Domain.Businesses;

public class Business<TModel, TId>(IRepository repository) : IBusiness
    where TModel : IModel
    where TId : struct
{
    protected readonly IRepository _repository = repository;
}
