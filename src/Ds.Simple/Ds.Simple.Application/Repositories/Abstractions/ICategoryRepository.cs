using Ds.Base.Domain.Paginateds;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;

namespace Ds.Simple.Application.Repositories.Abstractions;

public interface ICategoryRepository
{

    Category? Get(int id);
    PaginatedList<Category>? List(CategoryFilter filter);
    List<Category>? Filter(CategoryFilter filter);
    Category Save(Category model);
    Category Delete(int id);

}
