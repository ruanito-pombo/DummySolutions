using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Filters.Medias;
using Ds.Full.Domain.Models.Medias;

namespace Ds.Full.Domain.Businesses.Abstractions.Medias;

public interface ITitleBusiness : IAuditableBusiness
{

    Task<Title?> Get(long id);
    Task<List<Title>?> Filter(TitleFilter filter);
    Task<PaginatedList<Title>?> List(TitleFilter filter);
    Task<Title> Delete(long id);
    Task<Title> Save(Title model);

}
