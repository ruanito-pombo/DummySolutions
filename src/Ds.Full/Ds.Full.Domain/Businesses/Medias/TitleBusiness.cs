using Ds.Base.Domain.Businesses;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Businesses.Abstractions.Medias;
using Ds.Full.Domain.Filters.Medias;
using Ds.Full.Domain.Models.Medias;
using Ds.Full.Domain.Repositories.Abstractions.Medias;

namespace Ds.Full.Domain.Businesses.Medias;

public class TitleBusiness(ITitleRepository titleRepository) : AuditableBusiness(titleRepository), ITitleBusiness
{

    private readonly ITitleRepository _titleRepository = titleRepository;

    public async Task<Title?> Get(long id) =>
        await _titleRepository.Get(id);

    public async Task<List<Title>?> Filter(TitleFilter filter) =>
        await _titleRepository.Filter(filter);

    public async Task<PaginatedList<Title>?> List(TitleFilter filter) =>
        await _titleRepository.List(filter);

    public async Task<Title> Delete(long id) =>
        await _titleRepository.Delete(id);

    public async Task<Title> Save(Title model) =>
        await _titleRepository.Save(model);

}
