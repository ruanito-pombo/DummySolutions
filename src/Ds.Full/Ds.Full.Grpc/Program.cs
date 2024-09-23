global using Server = Ds.Full.Injection.Containers.DsFullContainer;
using System;
using System.Diagnostics;
using Ds.Base.Grpc.Builders;
using Ds.Full.Domain.Contexts.Abstractions;
using Ds.Full.Grpc.Infos;
using Ds.Full.Grpc.Services.Staffs;
using Ds.Full.Grpc.Settings;
using Ds.Full.Injection.Containers;
using Ds.Full.MySql.Contexts;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using static Ds.Base.Domain.Utils.ConfigurationsUtil;

var builder = GrpcBuilder.Create(args);
Server server = new(builder.Configuration.GetSection("GrpcInfo").Get<GrpcInfo>(),
    builder.Configuration.GetSection("GrpcSetting").Get<GrpcSetting>(), args);

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

builder.Services.AddDbContext<DsFullDatabaseContext>();
builder.Services.AddGrpc()
    .AddJsonTranscoding();
builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = Server.AppInfo.Title,
        Version = Server.AppInfo.Version,
        Description = Server.AppInfo.Description,
        Contact = new OpenApiContact()
        {
            Name = ((GrpcInfo)Server.AppInfo).PublisherName,
            Email = ((GrpcInfo)Server.AppInfo).PublisherEmail
        }
    });
});
builder.Services.AddGrpcReflection();

try
{
    server.InitializeServices(builder.Services);

    var app = builder.Build();

    server.InitializeApplication(app, true);

    using var scope = AsyncScopedLifestyle.BeginScope(server);
    if ((DsFullDatabaseContext)scope.GetInstance<IDsFullDatabaseContext>()
        is DsFullDatabaseContext dbContext && dbContext != null)
    {
        dbContext.Database.Migrate();

        app.UseSwagger();
        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{Server.AppInfo.Title} {Server.AppInfo.Version}"); });

        app.MapGrpcService<ProfileService>();
        app.MapGrpcService<UserService>();
        app.MapGet("/", async context => await Task.Run(() => context.Response.Redirect($"{((GrpcInfo)Server.AppInfo).Url}/swagger")));
        app.MapGrpcReflectionService();

        app.Run();
    }
}
catch { }