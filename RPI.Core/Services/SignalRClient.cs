using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RPI.Core.SignalR;

namespace RPI.Core.Services;

public class SignalRClient
{
    private record PinValueChangedDto(int Pin, string Value);
    
    private readonly IHubContext<RpiHub> _hubContext;

    public SignalRClient(IHubContext<RpiHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task NotifyPinChanged(int pin, string value)
    {
        await _hubContext.Clients.All.SendAsync("PinValueChanged", new PinValueChangedDto(pin, value));
    }
}