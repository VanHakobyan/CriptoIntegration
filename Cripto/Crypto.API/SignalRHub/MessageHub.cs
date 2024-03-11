using Microsoft.AspNetCore.SignalR;

namespace Crypto.API.SignalRHub;
public class MessageHub : Hub<IMessageHubClient>
{
    public override Task OnConnectedAsync()
    {
        Console.WriteLine("connect");
        return base.OnConnectedAsync();
    }
}