using Ds.Base.Domain.Models.Abstractions;

namespace Ds.Base.Domain.Paginateds.Abstractions;

public interface IPaginatedList<TModel>
    where TModel : IModel
{

    public int TotalRecords { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
    public IList<TModel>? Results { get; set; }

}
