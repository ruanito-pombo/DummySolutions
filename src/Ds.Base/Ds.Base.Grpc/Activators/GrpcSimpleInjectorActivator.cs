using Grpc.AspNetCore.Server;
using SimpleInjector;

namespace Ds.Base.Grpc.Activators;

public class GrpcSimpleInjectorActivator<T>(Container container) : IGrpcServiceActivator<T> where T : class
{

    private readonly Container container = container;

    public GrpcActivatorHandle<T> Create(IServiceProvider serviceProvider) =>
        new(container.GetInstance<T>(), false, null);

    public ValueTask ReleaseAsync(GrpcActivatorHandle<T> service) => default;

}