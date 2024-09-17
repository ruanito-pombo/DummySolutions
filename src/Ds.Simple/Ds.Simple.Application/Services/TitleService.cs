using Ds.Base.Domain.Models;
using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Services;
using Ds.Simple.Application.Businesses.Abstractions;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;
using Ds.Simple.Application.Services.Abstractions;

namespace Ds.Simple.Application.Services;

public class TitleService(ITitleBusiness titleBusiness)
    : IdentifiableService<IdentifiableLong, long>(titleBusiness), ITitleService
{

    private readonly ITitleBusiness _titleBusiness = titleBusiness;

    public Title? Get(long id) =>
        _titleBusiness.Get(id);

    public PaginatedList<Title>? List(TitleFilter filter) =>
        _titleBusiness.List(filter);

    public List<Title>? Filter(TitleFilter filter) =>
        _titleBusiness.Filter(filter);

    public Title Save(Title model) =>
        _titleBusiness.Save(model);

    public Title Delete(long id) =>
        _titleBusiness.Delete(id);

}
