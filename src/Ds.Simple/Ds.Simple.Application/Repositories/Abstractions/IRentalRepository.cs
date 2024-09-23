using Ds.Base.Domain.Paginateds;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;

namespace Ds.Simple.Application.Repositories.Abstractions;

public interface IRentalRepository
{

    Rental? Get(long id);
    PaginatedList<Rental>? List(RentalFilter filter);
    List<Rental>? Filter(RentalFilter filter);
    Rental Save(Rental model);
    Rental Delete(long id);

}
