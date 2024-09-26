using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Filters.Rentals;
using Ds.Full.Domain.Models.Rentals;

namespace Ds.Full.Domain.Businesses.Abstractions.Rentals;

public interface IRentalBusiness : IAuditableBusiness
{

    Task<Rental?> Get(long id);
    Task<List<Rental>?> Filter(RentalFilter filter);
    Task<PaginatedList<Rental>?> List(RentalFilter filter);
    Task<Rental> Delete(long id);
    Task<Rental> Save(Rental model);

}
