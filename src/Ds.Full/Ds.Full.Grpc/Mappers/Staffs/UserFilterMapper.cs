using Ds.Full.Domain.Filters.Staffs;
using Ds.Full.Proto.Protos.Staffs;

namespace Ds.Full.Grpc.Mappers.Staffs;

public static class UserFilterMapper
{

    public static UserFilter MapToModel(this UserFilterMsg userFilter) => new()
    {
        PageSize = userFilter.HasPageSize ? userFilter.PageSize : null,
        PageIndex = userFilter.HasPageIndex ? userFilter.PageIndex : null,
        UserId = userFilter.HasUserId ? userFilter.UserId : null,
        UserName = userFilter.HasUserName ? userFilter.UserName : null,
    };

    public static UserFilterMsg MapToMessage(this UserFilter userFilter) => new()
    {
        PageSize = userFilter.PageSize ?? 0,
        PageIndex = userFilter.PageIndex ?? 0,
        UserId = userFilter.UserId ?? 0,
        UserName = userFilter.UserName ?? string.Empty,
    };

}
