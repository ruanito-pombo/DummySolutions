using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Repositories.Abstractions;
using Ds.Full.Domain.Filters.Rentals;
using Ds.Full.Domain.Models.Rentals;

namespace Ds.Full.Domain.Repositories.Abstractions.Rentals;

public interface IRentalRepository : IIdentifiableRepository
{

    Rental? Get(long id);
    PaginatedList<Rental>? List(RentalFilter filter);
    List<Rental>? Filter(RentalFilter filter);
    Rental Save(Rental model);
    Rental Delete(long id);

}
