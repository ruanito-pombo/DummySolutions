using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Repositories.Abstractions;
using Ds.Full.Domain.Filters.Finances;
using Ds.Full.Domain.Models.Finances;

namespace Ds.Full.Domain.Repositories.Abstractions.Finances;

public interface IPaymentRepository : IIdentifiableRepository
{

    Payment? Get(long id);
    PaginatedList<Payment>? List(PaymentFilter filter);
    List<Payment>? Filter(PaymentFilter filter);
    Payment Save(Payment model);
    Payment Delete(long id);

}
