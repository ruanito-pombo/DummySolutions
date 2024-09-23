using Microsoft.Extensions.Configuration;
using static Ds.Base.Domain.Constants.DsBaseConstant;

namespace Ds.Base.Domain.Utils;

public static class ConfigurationsUtil
{

    public static bool HasDotNetEfCliArgs(string[] args) => string.Join(",", args.Select(s => s.ToString()).ToList())
        .Contains("--ef-cli", StringComparison.InvariantCultureIgnoreCase);

    public static bool HasDotNetEfCliDebugArgs(string[] args) => string.Join(",", args.Select(s => s.ToString()).ToList())
        .Contains("--ef-cli-debug", StringComparison.InvariantCultureIgnoreCase);

    public static string DotNetEfCliEnvironmentArgs(string[] args) => args.First(f => f.Contains("--ef-cli")).ToString() is string efArgs
        && !string.IsNullOrEmpty(efArgs) && efArgs[(efArgs.LastIndexOf('-') + 1)..] is string environment && !string.IsNullOrEmpty(environment)
        && AcceptableEnvironments.Contains(environment, StringComparer.InvariantCultureIgnoreCase) ? environment : "Localhost";

    public static IConfigurationRoot GetConfigurationRoot() =>
        (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? string.Empty)
        is string environment && !string.IsNullOrEmpty(environment) && $"appsettings.{environment}.json" is string appsettings
        && !string.IsNullOrEmpty(appsettings) && new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false).AddJsonFile(appsettings, optional: true) is IConfigurationBuilder configurationBuilder
        && configurationBuilder != null && configurationBuilder.Build() is IConfigurationRoot configurationRoot && configurationRoot != null
            ? configurationRoot
            : throw new Exception("Couldn't find configurations");

    public static void WriteOutputLog(string logMessage)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Out.Write("# ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Out.Write(logMessage);
        Console.ForegroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Out.WriteLine(" #");
    }

}
