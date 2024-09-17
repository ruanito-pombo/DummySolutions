using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Services.Abstractions;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;

namespace Ds.Simple.Application.Services.Abstractions;

public interface IRentalService : IIdentifiableService, IService
{

    Rental? Get(long id);
    PaginatedList<Rental>? List(RentalFilter filter);
    List<Rental>? Filter(RentalFilter filter);
    Rental Save(Rental model);
    Rental Delete(long id);

}
