using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Repositories.Abstractions;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;

namespace Ds.Simple.Application.Repositories.Abstractions;

public interface IPersonRepository : IIdentifiableRepository
{

    Person? Get(long id);
    PaginatedList<Person>? List(PersonFilter filter);
    List<Person>? Filter(PersonFilter filter);
    Person Save(Person model);
    Person Delete(long id);

}
