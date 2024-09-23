using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Filters.Staffs;
using Ds.Full.Domain.Models.Staffs;

namespace Ds.Full.Domain.Businesses.Abstractions.Staffs;

public interface IUserBusiness : IAuditableBusiness
{

    User? Get(int id);
    PaginatedList<User>? List(UserFilter filter);
    List<User>? Filter(UserFilter filter);
    User Save(User model);
    User Delete(int id);

}
