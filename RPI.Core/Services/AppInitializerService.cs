using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using RPI.Core.Abstract;
using RPI.Core.Devices.RaspberryPi;
using RPI.Core.Devices.RaspberryPi.Enums;

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
        var pinsConfiguration = new Dictionary<int, PinMode>
        {
            [1] = PinMode.Input,
            [2] = PinMode.Output
        };
        
        await _raspberryPi.Initialize(pinsConfiguration);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}