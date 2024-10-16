﻿using Ds.Base.Domain.Paginateds;
using Ds.Simple.Application.Filters;
using Ds.Simple.Application.Models;

namespace Ds.Simple.Application.Businesses.Abstractions;

public interface IUserBusiness
{

    User? Get(int id);
    PaginatedList<User>? List(UserFilter filter);
    List<User>? Filter(UserFilter filter);
    User Save(User model);
    User Delete(int id);

}
