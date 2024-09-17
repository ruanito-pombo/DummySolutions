using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Services.Abstractions;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;

namespace Ds.Simple.Application.Services.Abstractions;

public interface ITitleService : IIdentifiableService, IService
{

    Title? Get(long id);
    PaginatedList<Title>? List(TitleFilter filter);
    List<Title>? Filter(TitleFilter filter);
    Title Save(Title model);
    Title Delete(long id);

}
