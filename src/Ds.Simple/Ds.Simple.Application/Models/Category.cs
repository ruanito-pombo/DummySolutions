using Ds.Base.Domain.Models.Abstractions;
using Ds.Simple.Application.Enums;

namespace Ds.Simple.Application.Models;

public class Category : IModel
{

    public int Id { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
    public EsrbRating Rating { get; set; } = EsrbRating.Unknown;
    public List<Title>? TitleList { get; set; }

}
