using System;
using RPI.Core.Abstract;
using RPI.Core.Devices.RaspberryPi.Enums;

namespace RPI.Core.Devices.RaspberryPi.Actions.GetPinValue;

public class GetPinValueQueryResult : QueryResultBase<PinValue>
{
    public GetPinValueQueryResult(Guid id, Exception error) : base(id, error)
    {
    }

    public GetPinValueQueryResult(Guid id, PinValue value) : base(id, value)
    {
    }
}