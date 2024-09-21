namespace Ds.Base.Domain.ViewModels.Abstractions;

public interface IAuditableViewModel<TId> : IViewModel
    where TId : struct
{

    TId Id { get; set; }
    DateTimeOffset CreateDate { get; set; }
    DateTimeOffset UpdateDate { get; set; }

}
