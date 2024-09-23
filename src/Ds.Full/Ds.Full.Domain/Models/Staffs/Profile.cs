using Ds.Base.Domain.Models;
using Ds.Base.Domain.Models.Abstractions;

namespace Ds.Full.Domain.Models.Staffs;
public class Profile : AuditableInt, IModel
{

    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<User>? UserList { get; set; }

}
