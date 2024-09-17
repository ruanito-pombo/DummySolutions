namespace Ds.Base.Domain.WebApis.Results.Abstractions;

public interface IIdentifiableResult<TId> : IResult
    where TId : struct
{

    TId Id { get; set; }

}