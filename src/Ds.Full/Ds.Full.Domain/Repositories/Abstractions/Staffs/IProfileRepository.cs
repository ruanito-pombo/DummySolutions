using Ds.Base.Domain.Paginateds;
using Ds.Base.Domain.Repositories.Abstractions;
using Ds.Full.Domain.Filters.Staffs;
using Ds.Full.Domain.Models.Staffs;

namespace Ds.Full.Domain.Repositories.Abstractions.Staffs;

public interface IProfileRepository : IAuditableRepository
{

    Profile? Get(int id);
    PaginatedList<Profile>? List(ProfileFilter filter);
    List<Profile>? Filter(ProfileFilter filter);
    Profile Save(Profile model);
    Profile Delete(int id);

}
