using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace RPI.Core.SignalR;

public class RpiHub : Hub
{
    public override Task OnConnectedAsync()
    {
        Console.WriteLine("RpiHub - client connected");

        Clients.Client(Context.ConnectionId).SendAsync("Connected");
        
        return Task.CompletedTask;
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        Console.WriteLine("RpiHub - client disconnected");

        return Task.CompletedTask;
    }
}