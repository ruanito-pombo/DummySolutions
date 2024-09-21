using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ds.Full.Domain.Constants;

public static class DsFullConstant
{

    public const string SolutionName = "Ds.Full";

    public const int MinimumPageSize = 10;

    public static void Cls()
    {
        Console.Clear();
        Console.WriteLine("Ds.Full Project - DummySolutions®");
    }

    public static readonly JsonSerializerOptions _jsonDeserializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        IgnoreReadOnlyProperties = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        AllowTrailingCommas = true
    };

}
