using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Repositories.Abstractions;
using Ds.Full.Domain.Filters.Staffs;
using Ds.Full.Domain.Models.Staffs;

namespace Ds.Full.Domain.Repositories.Abstractions.Staffs;

public interface IProfileRepository : IAuditableRepository
{

    Task<Profile?> Get(int id);
    Task<List<Profile>?> Filter(ProfileFilter filter);
    Task<PaginatedList<Profile>?> List(ProfileFilter filter);
    Task<Profile> Delete(int id);
    Task<Profile> Save(Profile model);

}
