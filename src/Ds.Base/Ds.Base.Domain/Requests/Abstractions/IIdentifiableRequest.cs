namespace Ds.Base.Domain.Requests.Abstractions;

public interface IIdentifiableRequest<TId> : IRequest
    where TId : struct
{

    TId Id { get; set; }

}