using System;
using RPI.Core.Devices.RaspberryPi.Enums;

namespace RPI.Hardware.RaspberryPi.Extensions;

public static class EnumExtensions
{
    public static System.Device.Gpio.PinValue ToPinValue(this PinValue pinValue)
    {
        return pinValue switch
        {
            PinValue.High => System.Device.Gpio.PinValue.High,
            PinValue.Low => System.Device.Gpio.PinValue.Low,
            
            _ => throw new ArgumentOutOfRangeException(nameof(pinValue), pinValue, null)
        };
    }
    
    public static System.Device.Gpio.PinMode ToPinMode(this PinMode pinMode)
    {
        return pinMode switch
        {
            PinMode.Input => System.Device.Gpio.PinMode.Input,
            PinMode.Output => System.Device.Gpio.PinMode.Output,
            PinMode.InputPullDown => System.Device.Gpio.PinMode.InputPullDown,
            PinMode.InputPullUp => System.Device.Gpio.PinMode.InputPullUp,
            
            _ => throw new ArgumentOutOfRangeException(nameof(pinMode), pinMode, null)
        };
    }
    
    public static PinChangeTypes ToPinChangeTypes(this System.Device.Gpio.PinEventTypes pinEventTypes)
    {
        return Enum.Parse<PinChangeTypes>(pinEventTypes.ToString());
    }
}