using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Repositories.Abstractions;
using Ds.Full.Domain.Filters.Persons;
using Ds.Full.Domain.Models.Persons;

namespace Ds.Full.Domain.Repositories.Abstractions.Persons;

public interface IPersonRepository : IAuditableRepository
{

    Task<Person?> Get(long id);
    Task<List<Person>?> Filter(PersonFilter filter);
    Task<PaginatedList<Person>?> List(PersonFilter filter);
    Task<Person> Delete(long id);
    Task<Person> Save(Person model);

}
