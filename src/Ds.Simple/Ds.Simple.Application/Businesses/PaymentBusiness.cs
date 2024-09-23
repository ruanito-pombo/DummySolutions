using Ds.Base.Domain.Paginateds;
using Ds.Simple.Application.Businesses.Abstractions;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;
using Ds.Simple.Application.Repositories.Abstractions;

namespace Ds.Simple.Application.Businesses;

public class PaymentBusiness(IPaymentRepository paymentRepository) : IPaymentBusiness
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
