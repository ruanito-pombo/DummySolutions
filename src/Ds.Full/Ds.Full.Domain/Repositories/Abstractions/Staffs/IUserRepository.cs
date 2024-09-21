using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Repositories.Abstractions;
using Ds.Full.Domain.Filters.Staffs;
using Ds.Full.Domain.Models.Staffs;

namespace Ds.Full.Domain.Repositories.Abstractions.Staffs;

public interface IUserRepository : IIdentifiableRepository
{

    User? Get(int id);
    PaginatedList<User>? List(UserFilter filter);
    List<User>? Filter(UserFilter filter);
    User Save(User model);
    User Delete(int id);

}
