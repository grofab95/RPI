using RPI.Core.Abstract;

namespace RPI.Core.Devices.RaspberryPi.Actions.GetPinValue;

public class GetPinValueQuery : QueryBase<int, GetPinValueQueryResult>
{
    public GetPinValueQuery(int value) : base(value)
    {
    }
}