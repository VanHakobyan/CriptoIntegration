namespace Crypto.Core.SignalRHub;
public class MessageHub : Hub<IMessageHubClient>
{
    public override Task OnConnectedAsync()
    {

        Console.WriteLine("connect");
        return base.OnConnectedAsync();
    }

    public async Task SendOffersToUser(List<string> message)
    {
        await Clients.All.SendOffersToUser(message);
    }
}