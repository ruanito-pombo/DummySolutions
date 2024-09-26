using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Filters.Staffs;
using Ds.Full.Domain.Models.Staffs;

namespace Ds.Full.Domain.Businesses.Abstractions.Staffs;

public interface IUserBusiness : IAuditableBusiness
{

    Task<User?> Get(int id);
    Task<List<User>?> Filter(UserFilter filter);
    Task<PaginatedList<User>?> List(UserFilter filter);
    Task<User> Delete(int id);
    Task<User> Save(User model);

}
