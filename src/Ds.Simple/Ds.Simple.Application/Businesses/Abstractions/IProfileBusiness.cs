using Ds.Base.Domain.Paginateds;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;

namespace Ds.Simple.Application.Businesses.Abstractions;

public interface IProfileBusiness
{

    Profile? Get(int id);
    PaginatedList<Profile>? List(ProfileFilter filter);
    List<Profile>? Filter(ProfileFilter filter);
    Profile Save(Profile model);
    Profile Delete(int id);

}
