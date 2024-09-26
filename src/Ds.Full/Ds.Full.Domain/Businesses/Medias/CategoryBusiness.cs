using Ds.Base.Domain.Businesses;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Businesses.Abstractions.Medias;
using Ds.Full.Domain.Filters.Medias;
using Ds.Full.Domain.Models.Medias;
using Ds.Full.Domain.Repositories.Abstractions.Medias;

namespace Ds.Full.Domain.Businesses.Medias;

public class CategoryBusiness(ICategoryRepository categoryRepository) : AuditableBusiness(categoryRepository), ICategoryBusiness
{

    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<Category?> Get(int id) =>
        await _categoryRepository.Get(id);

    public async Task<List<Category>?> Filter(CategoryFilter filter) =>
        await _categoryRepository.Filter(filter);

    public async Task<PaginatedList<Category>?> List(CategoryFilter filter) =>
        await _categoryRepository.List(filter);

    public async Task<Category> Delete(int id) =>
        await _categoryRepository.Delete(id);

    public async Task<Category> Save(Category model) =>
        await _categoryRepository.Save(model);

}
