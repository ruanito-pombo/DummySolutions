using Ds.Base.Domain.Businesses.Abstractions;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Filters.Staffs;
using Ds.Full.Domain.Models.Staffs;

namespace Ds.Full.Domain.Businesses.Abstractions.Staffs;

public interface IProfileBusiness : IAuditableBusiness
{

    Task<Profile?> Get(int id);
    Task<List<Profile>?> Filter(ProfileFilter filter);
    Task<PaginatedList<Profile>?> List(ProfileFilter filter);
    Task<Profile> Delete(int id);
    Task<Profile> Save(Profile model);

}
