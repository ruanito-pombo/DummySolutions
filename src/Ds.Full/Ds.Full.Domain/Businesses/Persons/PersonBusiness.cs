using Ds.Base.Domain.Businesses;
using Ds.Base.Domain.Models;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Businesses.Abstractions.Persons;
using Ds.Full.Domain.Filters.Persons;
using Ds.Full.Domain.Models.Persons;
using Ds.Full.Domain.Repositories.Abstractions.Persons;

namespace Ds.Full.Domain.Businesses.Persons;

public class PersonBusiness(IPersonRepository personRepository)
    : AuditableBusiness<AuditableLong, long>(personRepository), IPersonBusiness
{

    private readonly IPersonRepository _personRepository = personRepository;

    public Person? Get(long id) =>
        _personRepository.Get(id);

    public PaginatedList<Person>? List(PersonFilter filter) =>
        _personRepository.List(filter);

    public List<Person>? Filter(PersonFilter filter) =>
        _personRepository.Filter(filter);

    public Person Save(Person model) =>
        _personRepository.Save(model);

    public Person Delete(long id) =>
        _personRepository.Delete(id);

    public async Task Remove(long id) => await Task.Delay(200);

}
