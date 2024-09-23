using Ds.Base.Domain.Paginateds;
using Ds.Simple.Application.Businesses.Abstractions;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;
using Ds.Simple.Application.Repositories.Abstractions;
namespace Ds.Simple.Application.Businesses;

public class CategoryBusiness(ICategoryRepository categoryRepository) : ICategoryBusiness
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
