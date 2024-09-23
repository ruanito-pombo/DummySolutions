using Ds.Base.Domain.Businesses;
using Ds.Base.Domain.Models;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Businesses.Abstractions.Rentals;
using Ds.Full.Domain.Filters.Rentals;
using Ds.Full.Domain.Models.Rentals;
using Ds.Full.Domain.Repositories.Abstractions.Rentals;

namespace Ds.Full.Domain.Businesses.Rentals;

public class RentalBusiness(IRentalRepository rentalRepository)
    : AuditableBusiness<AuditableLong, long>(rentalRepository), IRentalBusiness
{

    private readonly IRentalRepository _rentalRepository = rentalRepository;

    public Rental? Get(long id) =>
        _rentalRepository.Get(id);

    public PaginatedList<Rental>? List(RentalFilter filter) =>
        _rentalRepository.List(filter);

    public List<Rental>? Filter(RentalFilter filter) =>
        _rentalRepository.Filter(filter);

    public Rental Save(Rental model) =>
        _rentalRepository.Save(model);

    public Rental Delete(long id) =>
        _rentalRepository.Delete(id);

}
