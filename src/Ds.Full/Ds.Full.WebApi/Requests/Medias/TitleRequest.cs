using Ds.Base.Domain.Mappers.Abstractions;
using Ds.Base.Domain.Requests.Abstractions;
using Ds.Base.WebApi.Requests;
using Ds.Full.Domain.Enums.Medias;
using Ds.Full.Domain.Models.Medias;
using Ds.Full.WebApi.Requests.Inventories;
using Ds.Full.WebApi.Requests.Persons;

namespace Ds.Full.WebApi.Requests.Medias;

public class TitleRequest : AuditableRequestLong, IRequest, IMapTo<Title>
{

    public int CategoryId { get; set; } = 0;
    public long? AuthorId { get; set; }
    public long? ProducerId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; } = DateTime.MinValue;
    public MediaType MediaType { get; set; } = MediaType.Unknown;
    public ContentType ContentType { get; set; } = ContentType.Unknown;
    public ScoreRating? Rating { get; set; }
    public CategoryRequest? Category { get; set; }
    public PersonRequest? Author { get; set; }
    public PersonRequest? Producer { get; set; }
    public List<InventoryRequest>? InventoryList { get; set; }

    public Title MapTo() => new()
    {
        Id = Id,
        CreateDate = CreateDate,
        UpdateDate = UpdateDate,
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
        CreateDate = CreateDate,
        UpdateDate = UpdateDate,
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