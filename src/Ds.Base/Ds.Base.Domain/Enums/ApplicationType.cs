using System.ComponentModel;

namespace Ds.Base.Domain.Enums;

public enum ApplicationType : byte
{

    [Description("Unknown")]
    Unknown,

    [Description("Console")]
    Console,

    [Description("Grpc")]
    Grpc,

    [Description("WebApi")]
    WebApi,

}

public static class ApplicationTypeEnum
{

    public static string GetDescription(ApplicationType enumValue) => enumValue switch
    {
        ApplicationType.Console => "Console",
        ApplicationType.Grpc => "Grpc",
        ApplicationType.WebApi => "WebApi",
        _ => "Unknown",
    };
    public static ApplicationType GetValue(string stringValue) => stringValue switch
    {
        "Console" => ApplicationType.Console,
        "Grpc" => ApplicationType.Grpc,
        "WebApi" => ApplicationType.WebApi,
        _ => ApplicationType.Unknown,
    };

}