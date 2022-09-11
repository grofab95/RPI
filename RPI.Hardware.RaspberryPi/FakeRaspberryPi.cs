using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RPI.Core.Devices.RaspberryPi;
using RPI.Core.Devices.RaspberryPi.Enums;

namespace RPI.Hardware.RaspberryPi;

public class FakeRaspberryPi : IRaspberryPi
{
    public async Task Initialize(Dictionary<int, PinMode> pinsConfiguration)
    {
        await Task.Delay(1000);
    }

    public void Write(int pin, PinValue pinValue)
    {
        
    }

    public PinValue Read(int pin)
    {
        var values = Enum.GetValues<PinValue>();
        var random = new Random();

        return values[random.Next(0, values.Length)];
    }

    public event EventHandler<(int pin, PinChangeTypes changeType)> PinValueChanged;
}