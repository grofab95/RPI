using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RPI.Core.Devices.RaspberryPi;
using RPI.Core.Devices.RaspberryPi.Enums;
using RPI.Hardware.RaspberryPi.Extensions;
using RPI.Hardware.RaspberryPi.Options;
using PinMode = RPI.Core.Devices.RaspberryPi.Enums.PinMode;
using PinValue = RPI.Core.Devices.RaspberryPi.Enums.PinValue;

namespace RPI.Hardware.RaspberryPi;

public class RaspberryPi : IRaspberryPi, IDisposable
{
    public event EventHandler<(int pin, PinChangeTypes changeType)> PinValueChanged;

    private readonly ILogger<RaspberryPi> _logger;
    private readonly RaspberryPiOption _options;
    private readonly GpioController _device;
    private readonly List<int> _registeredPinValueChangedEvents;

    public RaspberryPi(IOptions<RaspberryPiOption> options, ILogger<RaspberryPi> logger)
    {
        _logger = logger;
        _options = options.Value;
        _device = new GpioController();
        _registeredPinValueChangedEvents = new();
    }
    
    public Task Initialize()
    {
        foreach (var (pin, pinMode) in _options.PinsConfiguration)
        {
            var pinNumber = int.Parse(pin);
            _device.OpenPin(pinNumber, pinMode.ToPinMode());
            
            if (pinMode == PinMode.Output)
            {
                continue;
            }

            const PinEventTypes eventTypes = PinEventTypes.Falling | PinEventTypes.Rising | PinEventTypes.None;
            
            _device.RegisterCallbackForPinValueChangedEvent(pinNumber, eventTypes, HandlePinChanged);     
            _registeredPinValueChangedEvents.Add(pinNumber);
        }

        return Task.CompletedTask;
    }

    private void HandlePinChanged(object sender, PinValueChangedEventArgs args)
    {
        _logger.LogInformation("HandlePinChanged | Data={@Data}", args);
        
        var changeType = args.ChangeType.ToPinChangeTypes();
        PinValueChanged?.Invoke(this, (args.PinNumber, changeType));
    }

    public void Write(int pin, PinValue pinValue)
    {
        _logger.LogInformation("Write | Pin={Pin}, Value={Value}", pin, pinValue);
        
        _device.Write(pin, pinValue.ToPinValue());
    }

    public PinValue Read(int pin)
    {
        var pinValue = _device.Read(pin);
        
        _logger.LogInformation("Read | Pin={Pin}, Value={Value}", pin, pinValue);
        
        return Enum.Parse<PinValue>(pinValue.ToString());
    }

    public void Dispose()
    {
        _logger.LogInformation("Dispose");
        _registeredPinValueChangedEvents.ForEach(pin => _device.UnregisterCallbackForPinValueChangedEvent(pin, HandlePinChanged));
        _device?.Dispose();
    }
}