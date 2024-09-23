using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Repositories.Abstractions;
using Ds.Full.Domain.Filters.Medias;
using Ds.Full.Domain.Models.Medias;

namespace Ds.Full.Domain.Repositories.Abstractions.Medias;

public interface ICategoryRepository : IAuditableRepository
{

    Category? Get(int id);
    PaginatedList<Category>? List(CategoryFilter filter);
    List<Category>? Filter(CategoryFilter filter);
    Category Save(Category model);
    Category Delete(int id);

}
