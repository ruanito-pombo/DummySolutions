using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Services.Abstractions;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;

namespace Ds.Simple.Application.Services.Abstractions;

public interface IPersonService : IIdentifiableService, IService
{

    Person? Get(long id);
    PaginatedList<Person>? List(PersonFilter filter);
    List<Person>? Filter(PersonFilter filter);
    Person Save(Person model);
    Person Delete(long id);

}
