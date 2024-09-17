using System.Text.Json;
using Microsoft.Build.Framework;
using Task = Microsoft.Build.Utilities.Task;

namespace Ds.Base.Domain.Tasks;

public class VersioningTask : Task
{

    public string? Content { get; set; }

    public string? ContentPath { get; set; }

    public string? Empty { get; set; }

    [Required]
    public string Query { get; set; } = "$";

    [Output]
    public string Result { get; private set; } = "1.0.0";

    public override bool Execute()
    {
        Log.LogMessage(MessageImportance.High, "Line: " + ContentPath);
        var content = ContentPath != null ?
            File.ReadAllText(ContentPath) : Content;

        var versioning = JsonSerializer.Deserialize<object>(content!) ?? new();

        Result = (versioning as dynamic).Mainstream;

        return true;
    }

}
