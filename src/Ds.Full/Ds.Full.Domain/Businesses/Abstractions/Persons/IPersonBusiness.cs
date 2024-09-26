using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Filters.Persons;
using Ds.Full.Domain.Models.Persons;

namespace Ds.Full.Domain.Businesses.Abstractions.Persons;

public interface IPersonBusiness : IAuditableBusiness
{

    Task<Person?> Get(long id);
    Task<List<Person>?> Filter(PersonFilter filter);
    Task<PaginatedList<Person>?> List(PersonFilter filter);
    Task<Person> Delete(long id);
    Task<Person> Save(Person model);

}
