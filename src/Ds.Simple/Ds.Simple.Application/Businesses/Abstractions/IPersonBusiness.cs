using Ds.Base.Domain.Paginateds;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;

namespace Ds.Simple.Application.Businesses.Abstractions;

public interface IPersonBusiness
{

    Person? Get(long id);
    PaginatedList<Person>? List(PersonFilter filter);
    List<Person>? Filter(PersonFilter filter);
    Person Save(Person model);
    Person Delete(long id);

}
