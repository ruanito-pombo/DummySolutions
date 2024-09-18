using Ds.Base.Domain.Entities.Abstractions;
using Ds.Base.Domain.Maping.Abstractions;
using Ds.Base.EntityFramework.Entities;
using Ds.Full.Domain.Enums.Medias;
using Ds.Full.Domain.Models.Medias;

namespace Ds.Full.MySql.Entities.Medias;

public class CategoryEntity : IdentifiableEntityInt, IEntity, IMap<CategoryEntity, Category>
{

    public string Description { get; set; } = string.Empty;
    public EsrbRating Rating { get; set; } = EsrbRating.Unknown;
    public List<TitleEntity>? TitleList { get; set; }

    public CategoryEntity() { }
    public CategoryEntity(Category model) => MapFrom(model);

    public static CategoryEntity MapFrom(Category? model) => model is null ? new() : new()
    {
        Id = model.Id,
        Description = model.Description,
        Rating = model.Rating,
    };

    public static CategoryEntity MapFrom(Category? model, string[]? include) => model is null ? new() : new()
    {
        Id = model.Id,
        Description = model.Description,
        Rating = model.Rating,

        TitleList = (include?.Any(a => a.Equals("TitleList")) ?? false) && model.TitleList != null
            ? model.TitleList.Select(s => TitleEntity.MapFrom(s, include))?.ToList() : null,
    };

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
