using Ds.Base.Domain.Businesses;
using Ds.Base.Domain.Models;
using Ds.Base.Domain.Paginateds;
using Ds.Simple.Application.Businesses.Abstractions;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;
using Ds.Simple.Application.Repositories.Abstractions;

namespace Ds.Simple.Application.Businesses;

public class UserBusiness(IUserRepository userRepository)
    : IdentifiableBusiness<IdentifiableInt, int>(userRepository), IUserBusiness
{

    private readonly IUserRepository _userRepository = userRepository;

    public User? Get(int id) =>
        _userRepository.Get(id);

    public PaginatedList<User>? List(UserFilter filter) =>
        _userRepository.List(filter);

    public List<User>? Filter(UserFilter filter) =>
        _userRepository.Filter(filter);

    public User Save(User model) =>
        _userRepository.Save(model);

    public User Delete(int id) =>
        _userRepository.Delete(id);

}
