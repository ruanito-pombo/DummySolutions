using Ds.Base.Domain.Businesses;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Businesses.Abstractions.Persons;
using Ds.Full.Domain.Filters.Persons;
using Ds.Full.Domain.Models.Persons;
using Ds.Full.Domain.Repositories.Abstractions.Persons;

namespace Ds.Full.Domain.Businesses.Persons;

public class PersonBusiness(IPersonRepository personRepository) : AuditableBusiness(personRepository), IPersonBusiness
{

    private readonly IPersonRepository _personRepository = personRepository;

    public async Task<Person?> Get(long id) =>
        await _personRepository.Get(id);

    public async Task<List<Person>?> Filter(PersonFilter filter) =>
        await _personRepository.Filter(filter);

    public async Task<PaginatedList<Person>?> List(PersonFilter filter) =>
        await _personRepository.List(filter);

    public async Task<Person> Delete(long id) =>
        await _personRepository.Delete(id);

    public async Task<Person> Save(Person model) =>
        await _personRepository.Save(model);

}
