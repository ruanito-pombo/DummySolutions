using Ds.Base.Domain.Businesses;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Businesses.Abstractions.Finances;
using Ds.Full.Domain.Filters.Finances;
using Ds.Full.Domain.Models.Finances;
using Ds.Full.Domain.Repositories.Abstractions.Finances;

namespace Ds.Full.Domain.Businesses.Finances;

public class PaymentBusiness(IPaymentRepository paymentRepository) : AuditableBusiness(paymentRepository), IPaymentBusiness
{

    private readonly IPaymentRepository _paymentRepository = paymentRepository;

    public async Task<Payment?> Get(long id) =>
        await _paymentRepository.Get(id);

    public async Task<List<Payment>?> Filter(PaymentFilter filter) =>
        await _paymentRepository.Filter(filter);

    public async Task<PaginatedList<Payment>?> List(PaymentFilter filter) =>
        await _paymentRepository.List(filter);

    public async Task<Payment> Delete(long id) =>
        await _paymentRepository.Delete(id);

    public async Task<Payment> Save(Payment model) =>
        await _paymentRepository.Save(model);

}
