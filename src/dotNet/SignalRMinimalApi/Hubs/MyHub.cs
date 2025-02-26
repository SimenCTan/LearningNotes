// SignalR Hub class
using Microsoft.AspNetCore.SignalR;

public class MyHub : Hub
{
    // Example method in the hub that will be called by clients
    public async Task Ping()
    {
        await Clients.Caller.SendAsync("Pong");
    }
}
