using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Models.Abstractions;
using Ds.Base.Domain.Services.Abstractions;

namespace Ds.Base.Domain.Services;

public class Service<TModel, TId>(IBusiness business) : IService
    where TModel : IModel
    where TId : struct
{
    protected readonly IBusiness _business = business;
}
