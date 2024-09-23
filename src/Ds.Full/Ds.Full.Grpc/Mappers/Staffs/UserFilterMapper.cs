using Ds.Full.Domain.Filters.Staffs;
using Ds.Full.Proto.Protos.Staffs;

namespace Ds.Full.Grpc.Mappers.Staffs;

public static class UserFilterMapper
{

    public static UserFilter MapToModel(this UserFilterMsg userFilter) => new()
    {
        PageSize = userFilter.PageOptions.HasPageSize ? userFilter.PageOptions.PageSize : null,
        PageIndex = userFilter.PageOptions.HasPageIndex ? userFilter.PageOptions.PageIndex : null,
        UserName = userFilter.HasUserName ? userFilter.UserName : null,
        PersonId = userFilter.HasPersonId ? userFilter.PersonId : null,
        PersonName = userFilter.HasPersonName ? userFilter.PersonName : null,
    };

    public static UserFilterMsg MapToMessage(this UserFilter userFilter) => new()
    {
        PageOptions = new()
        {
            PageSize = userFilter.PageSize ?? 0,
            PageIndex = userFilter.PageIndex ?? 0,
        },
        UserName = userFilter.UserName ?? string.Empty,
        PersonId = userFilter.PersonId ?? 0,
        PersonName = userFilter.PersonName ?? string.Empty,
    };

}
