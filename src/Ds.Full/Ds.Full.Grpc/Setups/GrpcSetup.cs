using Ds.Base.Grpc.Activators;
using Ds.Base.Injection.Containers;
using Ds.Full.Domain.Contexts.Abstractions;
using Ds.Full.Grpc.Infos;
using Ds.Full.Grpc.Services.Finances;
using Ds.Full.Grpc.Services.Inventories;
using Ds.Full.Grpc.Services.Medias;
using Ds.Full.Grpc.Services.Persons;
using Ds.Full.Grpc.Services.Rentals;
using Ds.Full.Grpc.Services.Staffs;
using Ds.Full.MySql.Contexts;
using Grpc.AspNetCore.Server;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Setup = Ds.Full.Injection.Containers.DsFullContainer;

namespace Ds.Full.Grpc.Setups;

public static class GrpcSetup
{

    public static WebApplication Build(this Setup setup, WebApplicationBuilder webApplicationBuilder, bool? register = false, bool? verify = false)
    {
        var webApplication = webApplicationBuilder.Build();

        webApplication.UseSwagger();
        webApplication.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{Setup.AppInfo.Title} {Setup.AppInfo.Version}"); });

        webApplication.MapGet("/", async context => await Task.Run(() => context.Response.Redirect($"{((GrpcInfo)Setup.AppInfo).Url}/swagger")));
        webApplication.MapGrpcReflectionService();
        webApplication.UseRouting();

        (webApplication as IApplicationBuilder)
            .UseSimpleInjector(setup);

        webApplication.UseEndpoints(endpoints =>
        {
            endpoints.MapGrpcService<CategoryService>();
            endpoints.MapGrpcService<InventoryService>();
            endpoints.MapGrpcService<PaymentService>();
            endpoints.MapGrpcService<PersonService>();
            endpoints.MapGrpcService<ProfileService>();
            endpoints.MapGrpcService<RentalService>();
            endpoints.MapGrpcService<TitleService>();
            endpoints.MapGrpcService<UserService>();
        });

        setup.InitializeApplication(webApplication, register, verify);

        return webApplication;
    }

    public static bool Initialize(this Setup setup, IServiceCollection services, bool? register = false)
    {
        setup.InitializeServices(services);

        services.Configure<KestrelServerOptions>(options => { options.AllowSynchronousIO = true; });

        services.AddDbContext<DsFullDatabaseContext>();

        services.AddGrpc(options => { options.EnableDetailedErrors = true; })
            .AddJsonTranscoding();
        services.AddGrpcReflection();

        services.AddGrpcSwagger();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = Setup.AppInfo.Title,
                Version = Setup.AppInfo.Version,
                Description = Setup.AppInfo.Description,
                Contact = new OpenApiContact()
                {
                    Name = ((GrpcInfo)Setup.AppInfo).PublisherName,
                    Email = ((GrpcInfo)Setup.AppInfo).PublisherEmail
                }
            });
        });

        services.AddSingleton(setup);
        services.AddSingleton(typeof(IGrpcServiceActivator<>),
            typeof(GrpcSimpleInjectorActivator<>));

        services.AddSimpleInjector(setup, options =>
        {
            options.AddAspNetCore();
        });

        setup.Register<CategoryService>();
        setup.Register<InventoryService>();
        setup.Register<PaymentService>();
        setup.Register<PersonService>();
        setup.Register<ProfileService>();
        setup.Register<RentalService>();
        setup.Register<TitleService>();
        setup.Register<UserService>();

        if (register ?? false)
        {
            setup.Register();
        }

        return true;
    }



    public static bool MigrateDatabase(this Setup setup)
    {
        if (!DsContainer.DotNetEfCliArgs)
        {
            using var scope = AsyncScopedLifestyle.BeginScope(setup);
            if ((DsFullDatabaseContext)scope.GetInstance<IDsFullDatabaseContext>()
                is DsFullDatabaseContext dbContext && dbContext != null)
            {
                dbContext.Database.Migrate();
            }
        }

        return true;
    }

}
