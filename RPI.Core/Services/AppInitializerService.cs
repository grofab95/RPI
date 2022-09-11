using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using RPI.Core.Abstract;
using RPI.Core.Devices.RaspberryPi;

namespace RPI.Core.Services;

public class AppInitializerService : IHostedService
{
    private readonly IRaspberryPi _raspberryPi;

    public AppInitializerService(IRaspberryPi raspberryPi, IEnumerable<IEventsDispatcherMarker> _)
    {
        _raspberryPi = raspberryPi;
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _raspberryPi.Initialize();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}