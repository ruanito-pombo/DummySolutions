using Ds.Base.Domain.Enums;
using Ds.Base.Domain.Settings.Abstractions;

namespace Ds.Base.Domain.Settings;

public class AppSetting : Setting, IAppSetting
{

    public ApplicationType Type { get; set; } = ApplicationType.Unknown;

}
