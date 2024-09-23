using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Repositories.Abstractions;
using Ds.Full.Domain.Filters.Medias;
using Ds.Full.Domain.Models.Medias;

namespace Ds.Full.Domain.Repositories.Abstractions.Medias;

public interface ITitleRepository : IAuditableRepository
{

    Title? Get(long id);
    PaginatedList<Title>? List(TitleFilter filter);
    List<Title>? Filter(TitleFilter filter);
    Title Save(Title model);
    Title Delete(long id);

}
