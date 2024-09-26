using Ds.Base.Grpc.Builders;
using Ds.Full.Grpc.Infos;
using Ds.Full.Grpc.Settings;
using Ds.Full.Grpc.Setups;
using Setup = Ds.Full.Injection.Containers.DsFullContainer;

var builder = GrpcBuilder.Create(args);
Setup setup = new(builder.Configuration.GetSection("GrpcInfo").Get<GrpcInfo>(),
    builder.Configuration.GetSection("GrpcSetting").Get<GrpcSetting>(), args);

try
{
    setup.Initialize(services: builder.Services, register: true);

    var app = setup.Build(webApplicationBuilder: builder, register: false, verify: true);

    setup.MigrateDatabase();

    app.Run();
}
catch { }