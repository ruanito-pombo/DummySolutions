using Ds.Base.Domain.Businesses;
using Ds.Base.Domain.Models;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Businesses.Abstractions.Medias;
using Ds.Full.Domain.Filters.Medias;
using Ds.Full.Domain.Models.Medias;
using Ds.Full.Domain.Repositories.Abstractions.Medias;

namespace Ds.Full.Domain.Businesses.Medias;

public class CategoryBusiness(ICategoryRepository categoryRepository)
    : AuditableBusiness<AuditableInt, int>(categoryRepository), ICategoryBusiness
{

    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public Category? Get(int id) =>
        _categoryRepository.Get(id);

    public PaginatedList<Category>? List(CategoryFilter filter) =>
        _categoryRepository.List(filter);

    public List<Category>? Filter(CategoryFilter filter) =>
        _categoryRepository.Filter(filter);

    public Category Save(Category model) =>
        _categoryRepository.Save(model);

    public Category Delete(int id) =>
        _categoryRepository.Delete(id);

}
