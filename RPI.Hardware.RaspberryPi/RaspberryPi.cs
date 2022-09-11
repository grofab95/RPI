using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Threading.Tasks;
using RPI.Core.Devices;
using RPI.Core.Devices.RaspberryPi;
using RPI.Core.Devices.RaspberryPi.Enums;
using RPI.Core.Extensions;
using PinMode = RPI.Core.Devices.RaspberryPi.Enums.PinMode;
using PinValue = RPI.Core.Devices.RaspberryPi.Enums.PinValue;

namespace RPI.Hardware.RaspberryPi;

public class RaspberryPi : IRaspberryPi, IDisposable
{
    public event EventHandler<(int pin, PinChangeTypes changeType)> PinValueChanged;

    private readonly GpioController _device;
    private readonly List<int> _registeredPinValueChangedEvents;

    public RaspberryPi()
    {
        _device = new GpioController();
        _registeredPinValueChangedEvents = new();
    }
    
    public Task Initialize(Dictionary<int, PinMode> pinsConfiguration)
    {
        foreach (var (pin, pinMode) in pinsConfiguration)
        {
            _device.SetPinMode(pin, pinMode.ConvertTo<System.Device.Gpio.PinMode>());
            if (pinMode == PinMode.Output)
            {
                continue;
            }
            
            _device.RegisterCallbackForPinValueChangedEvent(pin, PinEventTypes.None, HandlePinChanged);     
            _device.RegisterCallbackForPinValueChangedEvent(pin, PinEventTypes.Rising, HandlePinChanged);     
            _device.RegisterCallbackForPinValueChangedEvent(pin, PinEventTypes.Rising, HandlePinChanged);   
            
            _registeredPinValueChangedEvents.Add(pin);
        }

        return Task.CompletedTask;
    }

    private void HandlePinChanged(object sender, PinValueChangedEventArgs args)
    {
        var changeType = args.ChangeType.ConvertTo<PinChangeTypes>();
        PinValueChanged?.Invoke(this, (args.PinNumber, changeType));
    }

    public void Write(int pin, PinValue pinValue)
    {
        _device.Write(pin, pinValue.ConvertTo<System.Device.Gpio.PinValue>());
    }

    public PinValue Read(int pin)
    {
        var pinValue = _device.Read(pin);
        return Enum.Parse<PinValue>(pinValue.ToString());
    }

    public void Dispose()
    {
        _registeredPinValueChangedEvents.ForEach(pin => _device.UnregisterCallbackForPinValueChangedEvent(pin, HandlePinChanged));
        _device?.Dispose();
    }
}