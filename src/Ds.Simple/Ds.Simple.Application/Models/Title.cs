using Ds.Base.Core.Models.Abstractions;
using Ds.Simple.Application.Enums;

namespace Ds.Simple.Application.Models;

public class Title : IModel
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
    public Category? Category { get; set; }
    public Person? Author { get; set; }
    public Person? Producer { get; set; }
    public List<Inventory>? InventoryList { get; set; }

}