using Ds.Base.Domain.Settings.Abstractions;

namespace Ds.Base.Domain.Settings;

public class Setting : ISetting
{

    public virtual string Environment { get; set; } = string.Empty;

}
