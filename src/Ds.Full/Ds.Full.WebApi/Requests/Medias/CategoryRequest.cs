using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.Domain.Requests.Abstractions;
using Ds.Base.WebApi.Requests;
using Ds.Full.Domain.Enums.Medias;
using Ds.Full.Domain.Models.Medias;

namespace Ds.Full.WebApi.Requests.Medias;

public class CategoryRequest : IdentifiableRequestInt, IRequest, IMapTo<Category>
{

    public string Description { get; set; } = string.Empty;
    public EsrbRating Rating { get; set; } = EsrbRating.Unknown;
    public List<TitleRequest>? TitleList { get; set; }

    public Category MapTo() => new()
    {
        Id = Id,
        Description = Description,
        Rating = Rating,

        TitleList = TitleList?.Select(s => s.MapTo())?.ToList(),
    };

    public Category MapTo(string[]? except) => new()
    {
        Id = Id,
        Description = Description,
        Rating = Rating,

        TitleList = !(except?.Any(a => a.Equals("TitleList")) ?? false)
            ? TitleList?.Select(s => s.MapTo(except))?.ToList() : null,
    };

}
