namespace Ds.Base.Domain.Models.Abstractions;

public interface IIdentifiable<TId> : IModel
    where TId : struct
{

    TId Id { get; set; }

}