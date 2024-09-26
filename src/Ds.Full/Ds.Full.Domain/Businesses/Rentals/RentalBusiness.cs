using Ds.Base.Domain.Businesses;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Businesses.Abstractions.Rentals;
using Ds.Full.Domain.Filters.Rentals;
using Ds.Full.Domain.Models.Rentals;
using Ds.Full.Domain.Repositories.Abstractions.Rentals;

namespace Ds.Full.Domain.Businesses.Rentals;

public class RentalBusiness(IRentalRepository rentalRepository) : AuditableBusiness(rentalRepository), IRentalBusiness
{

    private readonly IRentalRepository _rentalRepository = rentalRepository;

    public async Task<Rental?> Get(long id) =>
        await _rentalRepository.Get(id);

    public async Task<List<Rental>?> Filter(RentalFilter filter) =>
        await _rentalRepository.Filter(filter);

    public async Task<PaginatedList<Rental>?> List(RentalFilter filter) =>
        await _rentalRepository.List(filter);

    public async Task<Rental> Delete(long id) =>
        await _rentalRepository.Delete(id);

    public async Task<Rental> Save(Rental model) =>
        await _rentalRepository.Save(model);

}
