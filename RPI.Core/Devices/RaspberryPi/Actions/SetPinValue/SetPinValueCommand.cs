using RPI.Core.Abstract;
using RPI.Core.Devices.RaspberryPi.Enums;

namespace RPI.Core.Devices.RaspberryPi.Actions.SetPinValue;

public class SetPinValueCommand : CommandBase<SetPinValueCommandResult>
{
    public int Pin  { get; }
    public PinValue PinValue { get; }

    public SetPinValueCommand(int pin, PinValue pinValue)
    {
        Pin = pin;
        PinValue = pinValue;
    }
}