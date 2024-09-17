using Ds.Base.Domain.Models;
using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Services;
using Ds.Simple.Application.Businesses.Abstractions;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;
using Ds.Simple.Application.Services.Abstractions;

namespace Ds.Simple.Application.Services;

public class UserService(IUserBusiness userBusiness)
    : IdentifiableService<IdentifiableInt, int>(userBusiness), IUserService
{

    private readonly IUserBusiness _userBusiness = userBusiness;

    public User? Get(int id) =>
        _userBusiness.Get(id);

    public PaginatedList<User>? List(UserFilter filter) =>
        _userBusiness.List(filter);

    public List<User>? Filter(UserFilter filter) =>
        _userBusiness.Filter(filter);

    public User Save(User model) =>
        _userBusiness.Save(model);

    public User Delete(int id) =>
        _userBusiness.Delete(id);

}
