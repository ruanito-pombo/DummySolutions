using Ds.Base.Core.Entities.Abstractions;
using Ds.Base.Core.Maping.Abstractions;
using Ds.Simple.Application.Enums;
using Ds.Simple.Application.Models;

namespace Ds.Simple.Application.Entities;

public class TitleEntity : IEntity, IMap<TitleEntity, Title>
{

    public long Id { get; set; } = 0;
    public int CategoryId { get; set; } = 0;
    public long AuthorId { get; set; } = 0;
    public long? ProducerId { get; set; } = 0;
    public string FullName { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; } = DateTime.MinValue;
    public MediaType MediaType { get; set; } = MediaType.Unknown;
    public ContentType ContentType { get; set; } = ContentType.Unknown;
    public ScoreRating? Rating { get; set; }
    public CategoryEntity? Category { get; set; }
    public PersonEntity? Author { get; set; }
    public PersonEntity? Producer { get; set; }
    public List<InventoryEntity>? InventoryList { get; set; }

    public TitleEntity() { }
    public TitleEntity(Title model) => MapFrom(model);

    public static TitleEntity MapFrom(Title? model) => model is null ? new() : new()
    {
        Id = model.Id,
        CategoryId = model.CategoryId,
        AuthorId = model.AuthorId,
        ProducerId = model.ProducerId,
        FullName = model.FullName,
        ReleaseDate = model.ReleaseDate,
        MediaType = model.MediaType,
        ContentType = model.ContentType,
        Rating = model.Rating,
    };

    public static TitleEntity MapFrom(Title? model, string[]? include) => model is null ? new() : new()
    {
        Id = model.Id,
        CategoryId = model.CategoryId,
        AuthorId = model.AuthorId,
        ProducerId = model.ProducerId,
        FullName = model.FullName,
        ReleaseDate = model.ReleaseDate,
        MediaType = model.MediaType,
        ContentType = model.ContentType,
        Rating = model.Rating,

        Category = (include?.Any(a => a.Equals("Category")) ?? false) && model.Category != null
            ? CategoryEntity.MapFrom(model.Category, include) : null,
        Author = (include?.Any(a => a.Equals("Author")) ?? false) && model.Author != null
            ? PersonEntity.MapFrom(model.Author, include) : null,
        Producer = (include?.Any(a => a.Equals("Producer")) ?? false) && model.Producer != null
            ? PersonEntity.MapFrom(model.Producer, include) : null,

        InventoryList = (include?.Any(a => a.Equals("InventoryList")) ?? false) && model.InventoryList != null
            ? model.InventoryList.Select(s => InventoryEntity.MapFrom(s, include))?.ToList() : null,
    };

    public Title MapTo() => new()
    {
        Id = Id,
        CategoryId = CategoryId,
        AuthorId = AuthorId,
        ProducerId = ProducerId,
        FullName = FullName,
        ReleaseDate = ReleaseDate,
        MediaType = MediaType,
        ContentType = ContentType,
        Rating = Rating,

        Category = Category?.MapTo(),
        Author = Author?.MapTo(),
        Producer = Producer?.MapTo(),

        InventoryList = InventoryList?.Select(s => s.MapTo())?.ToList(),
    };

    public Title MapTo(string[]? except) => new()
    {
        Id = Id,
        CategoryId = CategoryId,
        AuthorId = AuthorId,
        ProducerId = ProducerId,
        FullName = FullName,
        ReleaseDate = ReleaseDate,
        MediaType = MediaType,
        ContentType = ContentType,
        Rating = Rating,

        Category = !(except?.Any(a => a.Equals("Category")) ?? false)
            ? Category?.MapTo(except) : null,
        Author = !(except?.Any(a => a.Equals("Author")) ?? false)
            ? Author?.MapTo(except) : null,
        Producer = !(except?.Any(a => a.Equals("Producer")) ?? false)
            ? Producer?.MapTo(except) : null,

        InventoryList = !(except?.Any(a => a.Equals("InventoryList")) ?? false)
            ? InventoryList?.Select(s => s.MapTo(except))?.ToList() : null,
    };

}
