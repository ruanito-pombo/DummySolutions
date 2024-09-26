using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Filters.Finances;
using Ds.Full.Domain.Models.Finances;

namespace Ds.Full.Domain.Businesses.Abstractions.Finances;

public interface IPaymentBusiness : IAuditableBusiness
{

    Task<Payment?> Get(long id);
    Task<List<Payment>?> Filter(PaymentFilter filter);
    Task<PaginatedList<Payment>?> List(PaymentFilter filter);
    Task<Payment> Delete(long id);
    Task<Payment> Save(Payment model);

}
