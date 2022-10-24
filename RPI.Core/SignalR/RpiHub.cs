using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace RPI.Core.SignalR;

public class RpiHub : Hub
{
    private readonly ILogger<RpiHub> _logger;

    public RpiHub(ILogger<RpiHub> logger)
    {
        _logger = logger;
    }
    
    public override Task OnConnectedAsync()
    {
        _logger.LogInformation("Client connected with id={Id}", Context.ConnectionId);

        Clients.Client(Context.ConnectionId).SendAsync("Connected");
        
        return Task.CompletedTask;
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        _logger.LogInformation("Client disconnected");

        return Task.CompletedTask;
    }
}