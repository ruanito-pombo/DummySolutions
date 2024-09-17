namespace Ds.Base.Domain.Consoles.ViewModels.Abstractions;

public interface IIdentifiableViewModel<TId> : IViewModel
    where TId : struct
{

    TId Id { get; set; }

}
