using Ds.Base.Core.Filters.Abstractions;
using Ds.Base.Core.Filters;

namespace Ds.Simple.Application.Filters;

public class TitleFilter : Filter, IFilter
{

    public long? AuthorId { get; set; }
    public string? AuthorName { get; set; }
    public string? ProducerName { get; set; }
    public string? FullName { get; set; }

}
