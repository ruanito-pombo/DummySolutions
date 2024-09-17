using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Repositories.Abstractions;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;

namespace Ds.Simple.Application.Repositories.Abstractions;

public interface IRentalRepository : IIdentifiableRepository
{

    Rental? Get(long id);
    PaginatedList<Rental>? List(RentalFilter filter);
    List<Rental>? Filter(RentalFilter filter);
    Rental Save(Rental model);
    Rental Delete(long id);

}
