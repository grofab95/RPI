using MediatR;
using MediatR.Courier.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using RPI.Core.Abstract;
using RPI.Core.Devices.RaspberryPi;
using RPI.Core.Services;

namespace RPI.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCore(this IServiceCollection services)
    {
        services.AddSignalR();
        services.AddSingleton<SignalRClient>();
        services.AddMediatR(typeof(ServiceCollectionExtensions));
        services.AddCourier(typeof(ServiceCollectionExtensions).Assembly);
        services.AddSingleton<IEventsDispatcherMarker, RaspberryPiEventsDispatcher>();
        services.AddHostedService<AppInitializerService>();
    }
}