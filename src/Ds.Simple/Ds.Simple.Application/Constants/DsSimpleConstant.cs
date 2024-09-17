using System.Text.Json.Serialization;
using System.Text.Json;

namespace Ds.Simple.Application.Constants;

public static class DsSimpleConstant
{

    public const string SolutionName = "Ds.Simple";

    public static void Cls()
    {
        Console.Clear();
        Console.WriteLine("Ds.Simple Project - Console Application - DummySolutions®");
    }

    public static bool FailedValidation()
    {
        Console.WriteLine("... It appears to be something wrong with the data you providade, please review and try again ...");
        Console.WriteLine("type '[Y]es' if you want to retry or anything else to return to previous menu");
        return ((Console.ReadLine()?.Trim().ToUpper() ?? string.Empty) is string userInput && userInput.Length > 0 ? userInput[0..1] : "E") == "Y";
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
