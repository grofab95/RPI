using System;
using MediatR;
using RPI.Core.Abstract;
using RPI.Core.Devices.RaspberryPi.Actions.PinValueChanged;
using RPI.Core.Devices.RaspberryPi.Enums;
using RPI.Core.Services;

namespace RPI.Core.Devices.RaspberryPi;

public class RaspberryPiEventsDispatcher : IEventsDispatcherMarker, IDisposable
{
    private readonly IRaspberryPi _raspberryPi;
    private readonly IMediator _mediator;
    private readonly SignalRClient _signalRClient;

    public RaspberryPiEventsDispatcher(IRaspberryPi raspberryPi, IMediator mediator, SignalRClient signalRClient)
    {
        _raspberryPi = raspberryPi;
        _mediator = mediator;
        _signalRClient = signalRClient;

        _raspberryPi.PinValueChanged += DispatchPinValueChanged;
    }

    private void DispatchPinValueChanged(object sender, (int pin, PinChangeTypes changeType) e)
    {
        _mediator.Publish(new PinValueChangedEvent(e.pin, e.changeType)).Wait();

        _signalRClient.NotifyPinChanged(e.pin, e.changeType.ToString()).Wait();
    }

    public void Dispose()
    {
        _raspberryPi.PinValueChanged -= DispatchPinValueChanged;
    }
}