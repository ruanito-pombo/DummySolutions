using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.Domain.Models;
using Ds.Full.Domain.Enums.Medias;
using Ds.Full.Domain.Models.Medias;
using Ds.Full.WebApi.Results.Inventories;
using Ds.Full.WebApi.Results.Persons;
using IResult = Ds.Base.Domain.Results.Abstractions.IResult;

namespace Ds.Full.WebApi.Results.Medias;

public class TitleResult : AuditableLong, IResult, IMapFrom<TitleResult, Title>
{

    public int CategoryId { get; set; } = 0;
    public long AuthorId { get; set; } = 0;
    public long? ProducerId { get; set; } = 0;
    public string FullName { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; } = DateTime.MinValue;
    public MediaType MediaType { get; set; } = MediaType.Unknown;
    public ContentType ContentType { get; set; } = ContentType.Unknown;
    public ScoreRating? Rating { get; set; }
    public CategoryResult? Category { get; set; }
    public PersonResult? Author { get; set; }
    public PersonResult? Producer { get; set; }
    public List<InventoryResult>? InventoryList { get; set; }

    public TitleResult() { }
    public TitleResult(Title model) => MapFrom(model);

    public static TitleResult MapFrom(Title? model) => model is null ? new() : new()
    {
        Id = model.Id,
        CreateDate = model.CreateDate,
        UpdateDate = model.UpdateDate,
        CategoryId = model.CategoryId,
        AuthorId = model.AuthorId,
        ProducerId = model.ProducerId,
        FullName = model.FullName,
        ReleaseDate = model.ReleaseDate,
        MediaType = model.MediaType,
        ContentType = model.ContentType,
        Rating = model.Rating,
    };

    public static TitleResult MapFrom(Title? model, string[]? include) => model is null ? new() : new()
    {
        Id = model.Id,
        CreateDate = model.CreateDate,
        UpdateDate = model.UpdateDate,
        CategoryId = model.CategoryId,
        AuthorId = model.AuthorId,
        ProducerId = model.ProducerId,
        FullName = model.FullName,
        ReleaseDate = model.ReleaseDate,
        MediaType = model.MediaType,
        ContentType = model.ContentType,
        Rating = model.Rating,

        Category = (include?.Any(a => a.Equals("Category")) ?? false) && model.Category != null
            ? CategoryResult.MapFrom(model.Category, include) : null,
        Author = (include?.Any(a => a.Equals("Author")) ?? false) && model.Author != null
            ? PersonResult.MapFrom(model.Author, include) : null,
        Producer = (include?.Any(a => a.Equals("Producer")) ?? false) && model.Producer != null
            ? PersonResult.MapFrom(model.Producer, include) : null,

        InventoryList = (include?.Any(a => a.Equals("InventoryList")) ?? false) && model.InventoryList != null
            ? model.InventoryList.Select(s => InventoryResult.MapFrom(s, include))?.ToList() : null,
    };

}