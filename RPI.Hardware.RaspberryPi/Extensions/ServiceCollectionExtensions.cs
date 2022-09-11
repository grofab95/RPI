using System;
using Microsoft.Extensions.DependencyInjection;
using RPI.Core.Devices.RaspberryPi;

namespace RPI.Hardware.RaspberryPi.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddRaspberryPi(this IServiceCollection services)
    {
        if (OperatingSystem.IsWindows())
        {
            services.AddSingleton<IRaspberryPi, FakeRaspberryPi>();
        }
        else
        {
            services.AddSingleton<IRaspberryPi, RaspberryPi>();
        }
    }
}