using Ds.Full.Proto.Protos;
using Ds.Full.Domain.Models.Staffs;
using Ds.Full.Proto.Protos.Staffs;
using Ds.Full.Domain.Filters.Staffs;
using static Ds.Base.Grpc.Mappers.MessageMapper;

namespace Ds.Full.Grpc.Mappers.Staffs;

public static class UserRequestMapper
{

    public static UserFilter MapTo(this UserFilterMsg userFilter) => new()
    {
        PageSize = userFilter.PageOptions.HasPageSize ? userFilter.PageOptions.PageSize : null,
        PageIndex = userFilter.PageOptions.HasPageIndex ? userFilter.PageOptions.PageIndex : null,
        UserName = userFilter.HasUserName ? userFilter.UserName : null,
        PersonId = userFilter.HasPersonId ? userFilter.PersonId : null,
        PersonName = userFilter.HasPersonName ? userFilter.PersonName : null,
    };

    public static UserFilterMsg MapFrom(this UserFilter userFilter) => new()
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

    public static User MapTo(this UserMsg message) => new()
    {
        Id = message.Auditable?.Id ?? 0,
        CreateDate = ToDateTimeOffset(message.Auditable?.CreateDate),
        UpdateDate = ToDateTimeOffset(message.Auditable?.UpdateDate),
        ProfileId = message.ProfileId,
        UserName = message.UserName,
        IsActive = message.IsActive,
    };

    public static UserMsg MapTo(this User model) => new()
    {
        Auditable = new()
        {
            Id = model.Id,
            CreateDate = ToDateTimeOffsetMsg<DateTimeOffsetMsg>(model.CreateDate),
            UpdateDate = ToDateTimeOffsetMsg<DateTimeOffsetMsg>(model.UpdateDate),
        },
        ProfileId = model.ProfileId,
        UserName = model.UserName,
        IsActive = model.IsActive,
    };

}
