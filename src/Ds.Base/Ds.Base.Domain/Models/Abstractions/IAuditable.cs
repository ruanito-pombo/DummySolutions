namespace Ds.Base.Domain.Models.Abstractions;

public interface IAuditable<TId> : IModel
    where TId : struct
{

    TId Id { get; set; }
    DateTimeOffset CreateDate { get; set; }
    DateTimeOffset UpdateDate { get; set; }

}