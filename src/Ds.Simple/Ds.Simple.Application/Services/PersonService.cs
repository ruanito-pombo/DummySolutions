using Ds.Base.Domain.Models;
using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Services;
using Ds.Simple.Application.Businesses.Abstractions;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;
using Ds.Simple.Application.Services.Abstractions;

namespace Ds.Simple.Application.Services;

public class PersonService(IPersonBusiness personBusiness)
    : IdentifiableService<IdentifiableLong, long>(personBusiness), IPersonService
{

    private readonly IPersonBusiness _personBusiness = personBusiness;

    public Person? Get(long id) =>
        _personBusiness.Get(id);

    public PaginatedList<Person>? List(PersonFilter filter) =>
        _personBusiness.List(filter);

    public List<Person>? Filter(PersonFilter filter) =>
        _personBusiness.Filter(filter);

    public Person Save(Person model) =>
        _personBusiness.Save(model);

    public Person Delete(long id) =>
        _personBusiness.Delete(id);

}
