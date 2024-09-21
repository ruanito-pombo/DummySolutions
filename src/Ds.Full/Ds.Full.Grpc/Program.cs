global using Server = Ds.Full.Injection.Containers.DsFullContainer;
using Ds.Full.Domain.Contexts.Abstractions;
using Ds.Full.Grpc.Infos;
using Ds.Full.Grpc.Services.Staffs;
using Ds.Full.Grpc.Settings;
using Ds.Full.Injection.Containers;
using Ds.Full.MySql.Contexts;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SimpleInjector.Lifestyles;

var builder = WebApplication.CreateBuilder(args);
var container = new DsFullContainer(builder.Configuration.GetSection("GrpcAppInfo").Get<GrpcAppInfo>(),
    builder.Configuration.GetSection("GrpcAppSetting").Get<GrpcAppSetting>());

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

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
            Name = ((GrpcAppInfo)Server.AppInfo).PublisherName,
            Email = ((GrpcAppInfo)Server.AppInfo).PublisherEmail
        }
    });
});
builder.Services.AddGrpcReflection();

container.Initialize();
using var scope = AsyncScopedLifestyle.BeginScope(container);
if ((DsFullDatabaseContext)scope.GetInstance<IDsFullDatabaseContext>()
    is DsFullDatabaseContext dbContext && dbContext != null)
{
    dbContext.Database.Migrate();

    var app = builder.Build();
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{Server.AppInfo.Title} {Server.AppInfo.Version}"); });

    app.MapGrpcService<UserService>();
    app.MapGet("/", async context => await Task.Run(() => context.Response.Redirect($"{((GrpcAppInfo)Server.AppInfo).Url}/swagger")));
    app.MapGrpcReflectionService();

    app.Run();
}