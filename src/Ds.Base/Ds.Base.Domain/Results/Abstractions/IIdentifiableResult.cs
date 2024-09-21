namespace Ds.Base.Domain.Results.Abstractions;

public interface IIdentifiableResult<TId> : IResult
    where TId : struct
{

    TId Id { get; set; }

}