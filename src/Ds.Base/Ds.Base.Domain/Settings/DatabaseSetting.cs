using Ds.Base.Domain.Settings.Abstractions;

namespace Ds.Base.Domain.Settings;

public class DatabaseSetting : IDatabaseSetting
{

    public string ConnectionString { get; set; } = string.Empty;

}
