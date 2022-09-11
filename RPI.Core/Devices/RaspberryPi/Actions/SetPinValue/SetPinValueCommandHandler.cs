using System.Threading;
using System.Threading.Tasks;
using RPI.Core.Abstract.Messages;

namespace RPI.Core.Devices.RaspberryPi.Actions.SetPinValue;

public class SetPinValueCommandHandler : ICommandHandler<SetPinValueCommand, SetPinValueCommandResult>
{
    private readonly IRaspberryPi _raspberryPi;

    public SetPinValueCommandHandler(IRaspberryPi raspberryPi)
    {
        _raspberryPi = raspberryPi;
    }
    
    public Task<SetPinValueCommandResult> Handle(SetPinValueCommand command, CancellationToken cancellationToken)
    {
        _raspberryPi.Write(command.Pin, command.PinValue);

        return Task.FromResult(new SetPinValueCommandResult(command.Id));
    }
}