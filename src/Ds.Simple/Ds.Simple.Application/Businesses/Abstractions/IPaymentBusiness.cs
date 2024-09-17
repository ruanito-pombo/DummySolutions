using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Paginateds;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;

namespace Ds.Simple.Application.Businesses.Abstractions;

public interface IPaymentBusiness : IIdentifiableBusiness
{

    Payment? Get(long id);
    PaginatedList<Payment>? List(PaymentFilter filter);
    List<Payment>? Filter(PaymentFilter filter);
    Payment Save(Payment model);
    Payment Delete(long id);

}
