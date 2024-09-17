using Ds.Base.Core.Models.Abstractions;

namespace Ds.Simple.Application.Models;
public class Profile : IModel
{

    public int Id { get; set; } = 0;
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<User>? UserList { get; set; }

}
