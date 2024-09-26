using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Repositories.Abstractions;
using Ds.Full.Domain.Filters.Finances;
using Ds.Full.Domain.Models.Finances;

namespace Ds.Full.Domain.Repositories.Abstractions.Finances;

public interface IPaymentRepository : IAuditableRepository
{

    Task<Payment?> Get(long id);
    Task<List<Payment>?> Filter(PaymentFilter filter);
    Task<PaginatedList<Payment>?> List(PaymentFilter filter);
    Task<Payment> Delete(long id);
    Task<Payment> Save(Payment model);

}
