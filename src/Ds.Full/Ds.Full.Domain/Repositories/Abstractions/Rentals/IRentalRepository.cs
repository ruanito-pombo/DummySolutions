using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Repositories.Abstractions;
using Ds.Full.Domain.Filters.Rentals;
using Ds.Full.Domain.Models.Rentals;

namespace Ds.Full.Domain.Repositories.Abstractions.Rentals;

public interface IRentalRepository : IAuditableRepository
{

    Task<Rental?> Get(long id);
    Task<List<Rental>?> Filter(RentalFilter filter);
    Task<PaginatedList<Rental>?> List(RentalFilter filter);
    Task<Rental> Delete(long id);
    Task<Rental> Save(Rental model);

}
