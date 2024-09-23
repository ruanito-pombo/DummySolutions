using Ds.Full.Domain.Filters.Staffs;
using Ds.Full.Proto.Protos.Staffs;

namespace Ds.Full.Grpc.Mappers.Staffs;

public static class ProfileFilterMapper
{

    public static ProfileFilter MapToModel(this ProfileFilterMsg userFilter) => new()
    {
        PageSize = userFilter.HasPageSize ? userFilter.PageSize : null,
        PageIndex = userFilter.HasPageIndex ? userFilter.PageIndex : null,
        Code = userFilter.HasCode ? userFilter.Code : null,
        Description = userFilter.HasDescription ? userFilter.Description : null,
    };

    public static ProfileFilterMsg MapToMessage(this ProfileFilter userFilter) => new()
    {
        PageSize = userFilter.PageSize ?? 0,
        PageIndex = userFilter.PageIndex ?? 0,
        Code = userFilter.Code ?? string.Empty,
        Description = userFilter.Description ?? string.Empty,
    };

}
