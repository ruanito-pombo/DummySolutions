using Ds.Base.Domain.Paginateds;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;

namespace Ds.Simple.Application.Repositories.Abstractions;

public interface ITitleRepository
{

    Title? Get(long id);
    PaginatedList<Title>? List(TitleFilter filter);
    List<Title>? Filter(TitleFilter filter);
    Title Save(Title model);
    Title Delete(long id);

}
