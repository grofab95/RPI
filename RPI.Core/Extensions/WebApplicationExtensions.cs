using System;
using Microsoft.AspNetCore.Builder;
using RPI.Core.Devices.RaspberryPi;
using RPI.Core.Devices.RaspberryPi.Enums;
using RPI.Core.SignalR;

namespace RPI.Core.Extensions;

public static class WebApplicationExtensions
{
    private record EmptyDto;
    public static void ConfigureCore(this WebApplication app)
    {
        app.UseRouting();
        app.UseEndpoints(endpoint =>
        {
            endpoint.MapHub<RpiHub>("/rpi-hub");
            endpoint.MapPost("switch-led", (EmptyDto _, IRaspberryPi raspberryPi) =>
            {
                try
                {
                    var pinValue = raspberryPi.Read(4);
                    var valueToSet = pinValue == PinValue.High ? PinValue.Low : PinValue.High;
                    
                    raspberryPi.Write(4, valueToSet);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        });
    }
}