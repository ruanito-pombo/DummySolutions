using Ds.Base.Core.Entities.Abstractions;
using Ds.Base.Core.Maping.Abstractions;
using Ds.Simple.Application.Enums;
using Ds.Simple.Application.Models;

namespace Ds.Simple.Application.Entities;

public class CategoryEntity : IEntity, IMap<CategoryEntity, Category>
{

    public int Id { get; set; } = 0;
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
