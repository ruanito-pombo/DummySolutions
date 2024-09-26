using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Repositories.Abstractions;
using Ds.Full.Domain.Filters.Medias;
using Ds.Full.Domain.Models.Medias;

namespace Ds.Full.Domain.Repositories.Abstractions.Medias;

public interface ITitleRepository : IAuditableRepository
{

    Task<Title?> Get(long id);
    Task<List<Title>?> Filter(TitleFilter filter);
    Task<PaginatedList<Title>?> List(TitleFilter filter);
    Task<Title> Delete(long id);
    Task<Title> Save(Title model);

}
