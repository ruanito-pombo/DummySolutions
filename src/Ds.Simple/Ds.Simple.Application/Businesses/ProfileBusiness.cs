﻿using Ds.Base.Domain.Paginateds;
using Ds.Simple.Application.Businesses.Abstractions;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;
using Ds.Simple.Application.Repositories.Abstractions;
namespace Ds.Simple.Application.Businesses;

public class ProfileBusiness(IProfileRepository profileRepository) : IProfileBusiness
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
