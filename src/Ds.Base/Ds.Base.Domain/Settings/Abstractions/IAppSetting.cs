using Ds.Base.Domain.Enums;

namespace Ds.Base.Domain.Settings.Abstractions;

public interface IAppSetting : ISetting
{

    ApplicationType Type { get; set; }

}
