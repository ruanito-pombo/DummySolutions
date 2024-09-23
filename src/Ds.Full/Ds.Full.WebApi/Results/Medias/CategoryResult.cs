using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.Domain.Models;
using Ds.Full.Domain.Enums.Medias;
using Ds.Full.Domain.Models.Medias;
using IResult = Ds.Base.Domain.Results.Abstractions.IResult;

namespace Ds.Full.WebApi.Results.Medias;

public class CategoryResult : AuditableInt, IResult, IMapFrom<CategoryResult, Category>
{

    public string Description { get; set; } = string.Empty;
    public EsrbRating Rating { get; set; } = EsrbRating.Unknown;
    public List<TitleResult>? TitleList { get; set; }

    public CategoryResult() { }
    public CategoryResult(Category model) => MapFrom(model);

    public static CategoryResult MapFrom(Category? model) => model is null ? new() : new()
    {
        Id = model.Id,
        Description = model.Description,
        Rating = model.Rating,
    };

    public static CategoryResult MapFrom(Category? model, string[]? include) => model is null ? new() : new()
    {
        Id = model.Id,
        Description = model.Description,
        Rating = model.Rating,

        TitleList = (include?.Any(a => a.Equals("TitleList")) ?? false) && model.TitleList != null
            ? model.TitleList.Select(s => TitleResult.MapFrom(s, include))?.ToList() : null,
    };

}
