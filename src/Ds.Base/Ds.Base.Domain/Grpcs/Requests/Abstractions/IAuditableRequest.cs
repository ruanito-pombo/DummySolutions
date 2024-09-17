namespace Ds.Base.Domain.Grpcs.Requests.Abstractions;

public interface IAuditableRequest<TId> : IRequest
    where TId : struct
{

    TId Id { get; set; }
    DateTimeOffset CreateDate { get; set; }
    DateTimeOffset UpdateDate { get; set; }

}