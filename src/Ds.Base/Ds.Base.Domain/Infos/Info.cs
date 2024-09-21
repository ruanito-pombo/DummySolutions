using Ds.Base.Domain.Infos.Abstractions;

namespace Ds.Base.Domain.Infos;

public class Info : IInfo
{

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;

}
