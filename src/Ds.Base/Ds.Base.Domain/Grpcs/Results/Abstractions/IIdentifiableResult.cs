namespace Ds.Base.Domain.Grpcs.Results.Abstractions;

public interface IIdentifiableResult<TId> : IResult
    where TId : struct
{

    TId Id { get; set; }

}