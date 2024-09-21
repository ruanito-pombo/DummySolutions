using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Repositories.Abstractions;
using Ds.Full.Domain.Filters.Persons;
using Ds.Full.Domain.Models.Persons;

namespace Ds.Full.Domain.Repositories.Abstractions.Persons;

public interface IPersonRepository : IIdentifiableRepository
{

    Person? Get(long id);
    PaginatedList<Person>? List(PersonFilter filter);
    List<Person>? Filter(PersonFilter filter);
    Person Save(Person model);
    Person Delete(long id);

}
