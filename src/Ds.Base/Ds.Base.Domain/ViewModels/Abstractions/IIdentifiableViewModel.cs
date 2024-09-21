namespace Ds.Base.Domain.ViewModels.Abstractions;

public interface IIdentifiableViewModel<TId> : IViewModel
    where TId : struct
{

    TId Id { get; set; }

}
