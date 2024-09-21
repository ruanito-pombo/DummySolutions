namespace Ds.Base.Domain.Infos.Abstractions;

public interface IAppInfo : IInfo
{

    string Version { get; set; }
    DateTimeOffset StartDateTimeOffset { get; set; }

}
