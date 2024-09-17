using Ds.Base.Domain.Businesses;
using Ds.Base.Domain.Models;
using Ds.Base.Domain.Paginateds;
using Ds.Simple.Application.Businesses.Abstractions;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;
using Ds.Simple.Application.Repositories.Abstractions;

namespace Ds.Simple.Application.Businesses;

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
