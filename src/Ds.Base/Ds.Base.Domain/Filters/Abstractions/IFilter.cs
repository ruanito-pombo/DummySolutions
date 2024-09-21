namespace Ds.Base.Domain.Filters.Abstractions;
public interface IFilter
{

    int? PageSize { get; set; }
    int? PageIndex { get; set; }

}
