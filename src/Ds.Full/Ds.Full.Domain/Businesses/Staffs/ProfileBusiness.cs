using Ds.Base.Domain.Businesses;
using Ds.Base.Domain.Models;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Businesses.Abstractions.Staffs;
using Ds.Full.Domain.Filters.Staffs;
using Ds.Full.Domain.Models.Staffs;
using Ds.Full.Domain.Repositories.Abstractions.Staffs;

namespace Ds.Full.Domain.Businesses.Staffs;

public class ProfileBusiness(IProfileRepository profileRepository)
    : AuditableBusiness<AuditableInt, int>(profileRepository), IProfileBusiness
{

    private readonly IProfileRepository _profileRepository = profileRepository;

    public Profile? Get(int id) =>
        _profileRepository.Get(id);

    public PaginatedList<Profile>? List(ProfileFilter filter) =>
        _profileRepository.List(filter);

    public List<Profile>? Filter(ProfileFilter filter) =>
        _profileRepository.Filter(filter);

    public Profile Save(Profile model) =>
        _profileRepository.Save(model);

    public Profile Delete(int id) =>
        _profileRepository.Delete(id);

}
