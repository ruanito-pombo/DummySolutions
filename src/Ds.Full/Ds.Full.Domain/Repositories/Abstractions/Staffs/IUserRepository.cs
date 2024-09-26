using Ds.Base.Domain.Entities.Abstractions;
using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Repositories.Abstractions;
using Ds.Full.Domain.Filters.Staffs;
using Ds.Full.Domain.Models.Staffs;

namespace Ds.Full.Domain.Repositories.Abstractions.Staffs;

public interface IUserRepository : IAuditableRepository
{

    Task<User?> Get(int id);
    Task<List<User>?> Filter(UserFilter filter);
    Task<PaginatedList<User>?> List(UserFilter filter);
    Task<User> Delete(int id);
    Task<User> Save(User model);

}
