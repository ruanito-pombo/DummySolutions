using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Filters.Persons;
using Ds.Full.Domain.Models.Persons;

namespace Ds.Full.Domain.Businesses.Abstractions.Persons;

public interface IPersonBusiness : IIdentifiableBusiness
{

    Person? Get(long id);
    PaginatedList<Person>? List(PersonFilter filter);
    List<Person>? Filter(PersonFilter filter);
    Person Save(Person model);
    Person Delete(long id);

}
