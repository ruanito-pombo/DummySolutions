using Ds.Base.Domain.Filters;
using Ds.Base.Domain.Filters.Abstractions;

namespace Ds.Full.Domain.Filters.Medias;

public class TitleFilter : Filter, IFilter
{

    public long? AuthorId { get; set; }
    public string? AuthorName { get; set; }
    public string? ProducerName { get; set; }
    public string? FullName { get; set; }

}
