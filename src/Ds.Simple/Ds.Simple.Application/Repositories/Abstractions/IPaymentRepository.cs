using Ds.Base.Domain.Paginateds;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;

namespace Ds.Simple.Application.Repositories.Abstractions;

public interface IPaymentRepository
{

    Payment? Get(long id);
    PaginatedList<Payment>? List(PaymentFilter filter);
    List<Payment>? Filter(PaymentFilter filter);
    Payment Save(Payment model);
    Payment Delete(long id);

}
