using System.Collections.ObjectModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ds.Base.EntityFramework.Utils;

public static class DbSetUtil
{

    private static readonly JsonSerializerOptions _jsonDeserializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        IgnoreReadOnlyProperties = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        AllowTrailingCommas = true
    };

    public static Collection<T> LoadEmbeddedJson<T>(string dummyScope, string resourceName) where T : class
    {
        var assembly = Assembly.GetExecutingAssembly();

        string fullResourceName = $"{assembly.GetName().Name}.Entries.{dummyScope}.{resourceName}Entry.json";

        using Stream? stream = assembly.GetManifestResourceStream(fullResourceName)
            ?? throw new FileNotFoundException($"Resource '{fullResourceName}' not found in assembly.");

        using StreamReader reader = new(stream);
        string jsonContent = reader.ReadToEnd();

        return JsonSerializer.Deserialize<Collection<T>>(jsonContent, _jsonDeserializerOptions) ?? [];
    }

}
