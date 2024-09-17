using Ds.Base.Core.Models;
using Ds.Base.Core.Paginateds;
using Ds.Base.Core.Services;
using Ds.Simple.Application.Businesses.Abstractions;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;
using Ds.Simple.Application.Services.Abstractions;

namespace Ds.Simple.Application.Services;

public class RentalService(IRentalBusiness rentalBusiness)
    : IdentifiableService<IdentifiableLong, long>(rentalBusiness), IRentalService
{

    private readonly IRentalBusiness _rentalBusiness = rentalBusiness;

    public Rental? Get(long id) =>
        _rentalBusiness.Get(id);

    public PaginatedList<Rental>? List(RentalFilter filter) =>
        _rentalBusiness.List(filter);

    public List<Rental>? Filter(RentalFilter filter) =>
        _rentalBusiness.Filter(filter);

    public Rental Save(Rental model) =>
        _rentalBusiness.Save(model);

    public Rental Delete(long id) =>
        _rentalBusiness.Delete(id);

}
