using Ds.Base.Domain.Businesses;
using Ds.Base.Domain.Models;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Businesses.Abstractions.Staffs;
using Ds.Full.Domain.Filters.Staffs;
using Ds.Full.Domain.Models.Staffs;
using Ds.Full.Domain.Repositories.Abstractions.Staffs;

namespace Ds.Full.Domain.Businesses.Staffs;

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
