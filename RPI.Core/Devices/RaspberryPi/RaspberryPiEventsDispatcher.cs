using System;
using MediatR;
using RPI.Core.Abstract;
using RPI.Core.Devices.RaspberryPi.Actions.PinValueChanged;
using RPI.Core.Devices.RaspberryPi.Enums;

namespace RPI.Core.Devices.RaspberryPi;

public class RaspberryPiEventsDispatcher : IEventsDispatcherMarker, IDisposable
{
    private readonly IRaspberryPi _raspberryPi;
    private readonly IMediator _mediator;

    public RaspberryPiEventsDispatcher(IRaspberryPi raspberryPi, IMediator mediator)
    {
        _raspberryPi = raspberryPi;
        _mediator = mediator;

        _raspberryPi.PinValueChanged += DispatchPinValueChanged;
    }

    private void DispatchPinValueChanged(object sender, (int pin, PinChangeTypes changeType) e)
    {
        _mediator.Publish(new PinValueChangedEvent(e.pin, e.changeType)).Wait();
    }

    public void Dispose()
    {
        _raspberryPi.PinValueChanged -= DispatchPinValueChanged;
    }
}