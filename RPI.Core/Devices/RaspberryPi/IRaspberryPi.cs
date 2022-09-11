using System;
using System.Threading.Tasks;
using RPI.Core.Devices.RaspberryPi.Enums;

namespace RPI.Core.Devices.RaspberryPi;

public interface IRaspberryPi
{
    Task Initialize();

    void Write(int pin, PinValue pinValue);
    PinValue Read(int pin);

    event EventHandler<(int pin, PinChangeTypes changeType)> PinValueChanged;
}