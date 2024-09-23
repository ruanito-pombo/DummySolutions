using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using static Ds.Base.Domain.Constants.DsBaseConstant;
using static Ds.Base.Domain.Utils.ConfigurationsUtil;

namespace Ds.Base.Grpc.Builders;

public static class GrpcBuilder
{

    public static WebApplicationBuilder Create(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var environment = AcceptableEnvironments[0];

        if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Properties", "launchSettings.json")))
        {
            builder.Configuration.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "Properties", "launchSettings.json"), false, true);
            environment = builder.Configuration.GetSection("profiles").GetSection(builder.Environment.ApplicationName)
                .GetSection("environmentVariables")["ASPNETCORE_ENVIRONMENT"] ?? string.Empty;
        }

        if (HasDotNetEfCliArgs(args))
        {
            if (HasDotNetEfCliDebugArgs(args))
            {
                WriteOutputLog("Please select a VisualStudio instance to debug");
                Debugger.Launch();

                if (Debugger.IsAttached) { WriteOutputLog("Debugger attached!"); }
                else { WriteOutputLog("Debugger couldn't attach to Visual Studio, debug mode OFF!"); }
            }

            environment = DotNetEfCliEnvironmentArgs(args);
        }

        if (!builder.Environment.EnvironmentName.Equals(environment, StringComparison.InvariantCultureIgnoreCase))
        {
            builder.Configuration.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), $"appsettings.{environment}.json"), false, true);
            builder.Environment.EnvironmentName = environment;
        }

        return builder;
    }

}
