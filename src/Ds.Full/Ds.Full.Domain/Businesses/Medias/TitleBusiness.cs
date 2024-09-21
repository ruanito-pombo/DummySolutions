using Ds.Base.Domain.Businesses;
using Ds.Base.Domain.Models;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Businesses.Abstractions.Medias;
using Ds.Full.Domain.Filters.Medias;
using Ds.Full.Domain.Models.Medias;
using Ds.Full.Domain.Repositories.Abstractions.Medias;

namespace Ds.Full.Domain.Businesses.Medias;

public class TitleBusiness(ITitleRepository titleRepository)
    : IdentifiableBusiness<IdentifiableLong, long>(titleRepository), ITitleBusiness
{

    private readonly ITitleRepository _titleRepository = titleRepository;

    public Title? Get(long id) =>
        _titleRepository.Get(id);

    public PaginatedList<Title>? List(TitleFilter filter) =>
        _titleRepository.List(filter);

    public List<Title>? Filter(TitleFilter filter) =>
        _titleRepository.Filter(filter);

    public Title Save(Title model) =>
        _titleRepository.Save(model);

    public Title Delete(long id) =>
        _titleRepository.Delete(id);

}
