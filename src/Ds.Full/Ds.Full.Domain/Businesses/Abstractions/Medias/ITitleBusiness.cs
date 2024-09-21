using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Filters.Medias;
using Ds.Full.Domain.Models.Medias;

namespace Ds.Full.Domain.Businesses.Abstractions.Medias;

public interface ITitleBusiness : IIdentifiableBusiness
{

    Title? Get(long id);
    PaginatedList<Title>? List(TitleFilter filter);
    List<Title>? Filter(TitleFilter filter);
    Title Save(Title model);
    Title Delete(long id);

}
