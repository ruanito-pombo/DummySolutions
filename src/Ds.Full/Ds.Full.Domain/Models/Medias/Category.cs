using Ds.Base.Domain.Models;
using Ds.Base.Domain.Models.Abstractions;
using Ds.Full.Domain.Enums.Medias;

namespace Ds.Full.Domain.Models.Medias;

public class Category : AuditableInt, IModel
{

    public string Description { get; set; } = string.Empty;
    public EsrbRating Rating { get; set; } = EsrbRating.Unknown;
    public List<Title>? TitleList { get; set; }

}
