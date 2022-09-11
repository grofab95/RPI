using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RPI.Core.Devices.RaspberryPi;
using RPI.Hardware.RaspberryPi.Options;

namespace RPI.Hardware.RaspberryPi.Extensions;

public static class ServiceCollectionExtensions
{
    private const string InvalidConfiguration = "Invalid configuration";
    
    public static void AddRaspberryPi(this IServiceCollection services)
    {
        services.AddOptions<RaspberryPiOption>()
            .Configure<IConfiguration>(
                (o, c) => c.GetSection(RaspberryPiOption.SectionName).Bind(o))
            .Validate(options =>
            {
                var allKeysAreNumber = options.PinsConfiguration
                    .All(x => int.TryParse(x.Key, out _));
                
                return allKeysAreNumber;
            }, InvalidConfiguration);
        
        if (OperatingSystem.IsWindows())
        {
            services.AddSingleton<IRaspberryPi, RaspberryPi>();
        }
        else
        {
            services.AddSingleton<IRaspberryPi, RaspberryPi>();
        }
    }
}