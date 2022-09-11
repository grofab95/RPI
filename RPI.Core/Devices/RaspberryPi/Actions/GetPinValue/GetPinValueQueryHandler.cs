using System.Threading;
using System.Threading.Tasks;
using RPI.Core.Abstract;

namespace RPI.Core.Devices.RaspberryPi.Actions.GetPinValue;

public class GetPinValueQueryHandler : IQueryHandler<GetPinValueQuery, GetPinValueQueryResult>
{
    private readonly IRaspberryPi _raspberryPi;

    public GetPinValueQueryHandler(IRaspberryPi raspberryPi)
    {
        _raspberryPi = raspberryPi;
    }
    
    public Task<GetPinValueQueryResult> Handle(GetPinValueQuery query, CancellationToken cancellationToken)
    {
        var pinValue = _raspberryPi.Read(query.Value);

        return Task.FromResult(new GetPinValueQueryResult(query.Id, pinValue));
    }
}