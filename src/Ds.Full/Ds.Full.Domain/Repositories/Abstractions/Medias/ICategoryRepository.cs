using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Repositories.Abstractions;
using Ds.Full.Domain.Filters.Medias;
using Ds.Full.Domain.Models.Medias;

namespace Ds.Full.Domain.Repositories.Abstractions.Medias;

public interface ICategoryRepository : IAuditableRepository
{

    Task<Category?> Get(int id);
    Task<List<Category>?> Filter(CategoryFilter filter);
    Task<PaginatedList<Category>?> List(CategoryFilter filter);
    Task<Category> Delete(int id);
    Task<Category> Save(Category model);

}
