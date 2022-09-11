using System;
using RPI.Core.Abstract.Messages;

namespace RPI.Core.Devices.RaspberryPi.Actions.SetPinValue;

public class SetPinValueCommandResult : CommandResultBase
{
    public SetPinValueCommandResult(Guid id, Exception error) : base(id, error)
    {
    }

    public SetPinValueCommandResult(Guid id) : base(id)
    {
    }
}