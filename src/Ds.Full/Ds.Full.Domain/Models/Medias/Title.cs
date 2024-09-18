using Ds.Base.Domain.Models;
using Ds.Base.Domain.Models.Abstractions;
using Ds.Full.Domain.Enums.Medias;
using Ds.Full.Domain.Models.Inventories;
using Ds.Full.Domain.Models.Persons;

namespace Ds.Full.Domain.Models.Medias;

public class Title : AuditableLong, IModel
{

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