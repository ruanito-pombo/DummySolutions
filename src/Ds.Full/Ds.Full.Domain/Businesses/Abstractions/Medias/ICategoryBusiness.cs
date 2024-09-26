using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Filters.Medias;
using Ds.Full.Domain.Models.Medias;

namespace Ds.Full.Domain.Businesses.Abstractions.Medias;

public interface ICategoryBusiness : IAuditableBusiness
{

    Task<Category?> Get(int id);
    Task<List<Category>?> Filter(CategoryFilter filter);
    Task<PaginatedList<Category>?> List(CategoryFilter filter);
    Task<Category> Delete(int id);
    Task<Category> Save(Category model);

}
