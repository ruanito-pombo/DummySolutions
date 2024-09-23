using Ds.Base.Domain.Businesses;
using Ds.Base.Domain.Models;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Businesses.Abstractions.Finances;
using Ds.Full.Domain.Filters.Finances;
using Ds.Full.Domain.Models.Finances;
using Ds.Full.Domain.Repositories.Abstractions.Finances;

namespace Ds.Full.Domain.Businesses.Finances;

public class PaymentBusiness(IPaymentRepository paymentRepository)
    : AuditableBusiness<AuditableLong, long>(paymentRepository), IPaymentBusiness
{

    private readonly IPaymentRepository _paymentRepository = paymentRepository;

    public Payment? Get(long id) =>
        _paymentRepository.Get(id);

    public PaginatedList<Payment>? List(PaymentFilter filter) =>
        _paymentRepository.List(filter);

    public List<Payment>? Filter(PaymentFilter filter) =>
        _paymentRepository.Filter(filter);

    public Payment Save(Payment model) =>
        _paymentRepository.Save(model);

    public Payment Delete(long id) =>
        _paymentRepository.Delete(id);

}
