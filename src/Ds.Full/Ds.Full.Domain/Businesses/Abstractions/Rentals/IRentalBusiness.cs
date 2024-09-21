using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Filters.Rentals;
using Ds.Full.Domain.Models.Rentals;

namespace Ds.Full.Domain.Businesses.Abstractions.Rentals;

public interface IRentalBusiness : IIdentifiableBusiness
{

    Rental? Get(long id);
    PaginatedList<Rental>? List(RentalFilter filter);
    List<Rental>? Filter(RentalFilter filter);
    Rental Save(Rental model);
    Rental Delete(long id);

}
