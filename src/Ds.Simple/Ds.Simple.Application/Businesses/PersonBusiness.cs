using Ds.Base.Core.Businesses;
using Ds.Base.Core.Models;
using Ds.Base.Core.Paginateds;
using Ds.Simple.Application.Businesses.Abstractions;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;
using Ds.Simple.Application.Repositories.Abstractions;

namespace Ds.Simple.Application.Businesses;

public class PersonBusiness(IPersonRepository personRepository)
    : IdentifiableBusiness<IdentifiableLong, long>(personRepository), IPersonBusiness
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
