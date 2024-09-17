using Ds.Base.Domain.Businesses;
using Ds.Base.Domain.Models;
using Ds.Base.Domain.Paginateds;
using Ds.Simple.Application.Businesses.Abstractions;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;
using Ds.Simple.Application.Repositories.Abstractions;

namespace Ds.Simple.Application.Businesses;

public class RentalBusiness(IRentalRepository rentalRepository)
    : IdentifiableBusiness<IdentifiableLong, long>(rentalRepository), IRentalBusiness
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
