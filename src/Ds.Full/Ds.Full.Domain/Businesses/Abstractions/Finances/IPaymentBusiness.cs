using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Filters.Finances;
using Ds.Full.Domain.Models.Finances;

namespace Ds.Full.Domain.Businesses.Abstractions.Finances;

public interface IPaymentBusiness : IIdentifiableBusiness
{

    Payment? Get(long id);
    PaginatedList<Payment>? List(PaymentFilter filter);
    List<Payment>? Filter(PaymentFilter filter);
    Payment Save(Payment model);
    Payment Delete(long id);

}
