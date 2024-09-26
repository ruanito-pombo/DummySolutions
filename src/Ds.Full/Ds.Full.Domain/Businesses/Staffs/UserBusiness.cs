using Ds.Base.Domain.Businesses;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Businesses.Abstractions.Staffs;
using Ds.Full.Domain.Filters.Staffs;
using Ds.Full.Domain.Models.Staffs;
using Ds.Full.Domain.Repositories.Abstractions.Staffs;

namespace Ds.Full.Domain.Businesses.Staffs;

public class UserBusiness(IUserRepository userRepository) : AuditableBusiness(userRepository), IUserBusiness
{

    private readonly IUserRepository _userRepository = userRepository;

    public async Task<User?> Get(int id) =>
        await _userRepository.Get(id);

    public async Task<List<User>?> Filter(UserFilter filter) =>
        await _userRepository.Filter(filter);

    public async Task<PaginatedList<User>?> List(UserFilter filter) =>
        await _userRepository.List(filter);

    public async Task<User> Save(User model) =>
        await _userRepository.Save(model);

    public async Task<User> Delete(int id) =>
        await _userRepository.Delete(id);

}
