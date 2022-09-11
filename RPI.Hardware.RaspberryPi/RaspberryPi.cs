using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using RPI.Core.Devices.RaspberryPi;
using RPI.Core.Devices.RaspberryPi.Enums;
using RPI.Core.Extensions;
using RPI.Hardware.RaspberryPi.Options;
using PinMode = RPI.Core.Devices.RaspberryPi.Enums.PinMode;
using PinValue = RPI.Core.Devices.RaspberryPi.Enums.PinValue;

namespace RPI.Hardware.RaspberryPi;

public class RaspberryPi : IRaspberryPi, IDisposable
{
    public event EventHandler<(int pin, PinChangeTypes changeType)> PinValueChanged;

    private readonly RaspberryPiOption _options;
    private readonly GpioController _device;
    private readonly List<int> _registeredPinValueChangedEvents;

    public RaspberryPi(IOptions<RaspberryPiOption> options)
    {
        _options = options.Value;
        _device = new GpioController();
        _registeredPinValueChangedEvents = new();
    }
    
    public Task Initialize()
    {
        foreach (var (pin, pinMode) in _options.PinsConfiguration)
        {
            var pinNumber = int.Parse(pin);
            _device.SetPinMode(pinNumber, pinMode.ConvertTo<System.Device.Gpio.PinMode>());
            if (pinMode == PinMode.Output)
            {
                continue;
            }
            
            _device.RegisterCallbackForPinValueChangedEvent(pinNumber, PinEventTypes.None, HandlePinChanged);     
            _device.RegisterCallbackForPinValueChangedEvent(pinNumber, PinEventTypes.Rising, HandlePinChanged);     
            _device.RegisterCallbackForPinValueChangedEvent(pinNumber, PinEventTypes.Rising, HandlePinChanged);   
            
            _registeredPinValueChangedEvents.Add(pinNumber);
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