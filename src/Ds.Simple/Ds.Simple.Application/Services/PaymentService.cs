using Ds.Base.Domain.Models;
using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Services;
using Ds.Simple.Application.Businesses.Abstractions;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;
using Ds.Simple.Application.Services.Abstractions;

namespace Ds.Simple.Application.Services;

public class PaymentService(IPaymentBusiness paymentBusiness)
    : IdentifiableService<IdentifiableLong, long>(paymentBusiness), IPaymentService
{

    private readonly IPaymentBusiness _paymentBusiness = paymentBusiness;

    public Payment? Get(long id) =>
        _paymentBusiness.Get(id);

    public PaginatedList<Payment>? List(PaymentFilter filter) =>
        _paymentBusiness.List(filter);

    public List<Payment>? Filter(PaymentFilter filter) =>
        _paymentBusiness.Filter(filter);

    public Payment Save(Payment model) =>
        _paymentBusiness.Save(model);

    public Payment Delete(long id) =>
        _paymentBusiness.Delete(id);

}
