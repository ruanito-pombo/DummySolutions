namespace Ds.Base.Domain.Filters.Abstractions;
public interface IFilter
{

    public int PageSize { get; set; }
    public int PageIndex { get; set; }

}
