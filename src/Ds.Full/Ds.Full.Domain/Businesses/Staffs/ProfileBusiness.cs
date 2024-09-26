using Ds.Base.Domain.Businesses;
using Ds.Base.Domain.Paginateds;
using Ds.Full.Domain.Businesses.Abstractions.Staffs;
using Ds.Full.Domain.Filters.Staffs;
using Ds.Full.Domain.Models.Staffs;
using Ds.Full.Domain.Repositories.Abstractions.Staffs;

namespace Ds.Full.Domain.Businesses.Staffs;

public class ProfileBusiness(IProfileRepository profileRepository) : AuditableBusiness(profileRepository), IProfileBusiness
{

    private readonly IProfileRepository _profileRepository = profileRepository;

    public async Task<Profile?> Get(int id) =>
        await _profileRepository.Get(id);

    public async Task<List<Profile>?> Filter(ProfileFilter filter) =>
        await _profileRepository.Filter(filter);

    public async Task<PaginatedList<Profile>?> List(ProfileFilter filter) =>
        await _profileRepository.List(filter);

    public async Task<Profile> Delete(int id) =>
        await _profileRepository.Delete(id);

    public async Task<Profile> Save(Profile model) =>
        await _profileRepository.Save(model);

}
